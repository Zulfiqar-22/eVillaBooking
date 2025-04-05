using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Application.Utility;
using eVillaBooking.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Stripe.FinancialConnections;
using System.Security.Claims;
using Session = Stripe.Checkout.Session;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;
using SessionService = Stripe.Checkout.SessionService;

namespace eVillaBooking.Presentation.Controllers
{
    public class BookingController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        public BookingController(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
            
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult FinalizeBooking(DateOnly checkInDate, int nights,int villaId)
        {     
            var claimIdentity=(ClaimsIdentity)User.Identity!;
            var userId=claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            ApplicationUser applicationUser=_unitofwork.ApplicationUserUOW.Get(au=>au.Id==userId);
            
            Booking booking = new()
            {
                CheckInDate = checkInDate,
                Nights = nights,
                VillasId = villaId,
                CheckoutDate = checkInDate.AddDays(nights),
                Villas = _unitofwork.villaRepositoryUOW.Get(v => v.Id == villaId, Includeproperty: "AmenitiesList"),
                Name=applicationUser.Name,
                Email=applicationUser.Email!,
                Phone=applicationUser.PhoneNumber,
                UserId=userId
                

            };

            booking.TotalCost = booking.Villas.Price * nights;
            return View(booking);
        }
        [Authorize,HttpPost]
        public IActionResult FinalizeBooking(Booking booking)
        {
            Villas villas=_unitofwork.villaRepositoryUOW.Get(v=>v.Id==booking.VillasId);
            booking.TotalCost = villas.Price * booking.Nights;
            booking.BookingDate=DateTime.Now;
            booking.ActualCheckInDate = booking.CheckInDate.ToDateTime(TimeOnly.MinValue);
            booking.ActualCheckOutDate = booking.CheckInDate.ToDateTime(TimeOnly.MinValue).AddDays(Convert.ToInt32(booking.Nights));

            //booking.Status=StaticDetails.StatusApproved;
            booking.Status = StaticDetails.StatusPending;
            _unitofwork.BookingRepositroyUow.Add(booking);
            _unitofwork.Save();

            var domain = Request.Scheme + "://" + Request.Host.Value + "/";

            SessionCreateOptions options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
    {
            new SessionLineItemOptions
        {
            Quantity = 1,
             PriceData=new SessionLineItemPriceDataOptions
             {
                 Currency="usd",
                 UnitAmount=(long)(booking.TotalCost*100),
                 ProductData= new SessionLineItemPriceDataProductDataOptions
                 {
                     Name=booking.Name,
                     
                 }

             }
        },
    },
                Mode = "payment",
                SuccessUrl = domain + $"Booking/BookingConfirmation?bookingId={booking.Id}",
                CancelUrl = domain + $"Booking/FinalizeBooking?checkInDate={booking.CheckInDate}&nights={booking.Nights}&villaId={booking.VillasId}"
             };
            var service = new SessionService();
            Session session= service.Create(options);

            _unitofwork.BookingRepositroyUow.UpdateStripePaymentId(booking.Id, session.Id, session.PaymentIntentId);
            _unitofwork.Save();


            return Redirect(session.Url);

        }
         
        public IActionResult BookingConfirmation(int bookingId)
        {
            Booking bookingFromDb= _unitofwork.BookingRepositroyUow.Get(b=>b.Id==bookingId,Includeproperty:"Villas,User");

            if(bookingFromDb.Status==StaticDetails.StatusPending)
            {
                SessionService sessionService= new SessionService();
                Session session=sessionService.Get(bookingFromDb.StripeSessionId);


                if(session.PaymentStatus=="paid")
                {
                    _unitofwork.BookingRepositroyUow.UpdateStatus(bookingId, StaticDetails.StatusApproved);
                    _unitofwork.BookingRepositroyUow.UpdateStripePaymentId(bookingId,session.Id,session.PaymentIntentId);
                    _unitofwork.Save();

                }
            }
            
            return View(bookingId);
        }
        #region APIs
        [HttpGet,Authorize]
        public IActionResult GetAllDetails()
        {
            IEnumerable<Booking> bookingobj=Enumerable.Empty<Booking>();
            if (User.IsInRole(StaticDetails.Role_Admin))
               { bookingobj = _unitofwork.BookingRepositroyUow.GetAll(Includeproperty: "User,Villas");
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                bookingobj = _unitofwork.BookingRepositroyUow.GetAll(b => b.UserId == userId, Includeproperty: "User,Villas");
            }
        
         return Json(new {data=bookingobj});
        }

        #endregion

        public IActionResult Details(int id)
        {
            var BookingFromDb = _unitofwork.BookingRepositroyUow.Get(b => b.Id == id,Includeproperty: "User,Villas.AmenitiesList");
            return View(BookingFromDb);
        }


    }

}
