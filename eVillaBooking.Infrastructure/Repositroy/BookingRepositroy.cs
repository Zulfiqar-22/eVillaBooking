using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Application.Utility;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Infrastructure.Repositroy
{
	public class BookingRepositroy : Repositroy<Booking>, IBookingRepositroy
	{
		private readonly ApplicationDbContext _Db;
        public BookingRepositroy(ApplicationDbContext Db) : base(Db) 
        {
			_Db = Db;
        }

        public void Update(Booking booking)
		{
			_Db.Update(booking);
		}

        public void UpdateStatus(int bookingId, string bookingStatus)
        {
            Booking bookingFromDb=_Db.Bookings.FirstOrDefault(b=>b.Id == bookingId)!;
            if(bookingFromDb is not null )
            {
                bookingFromDb.Status= bookingStatus;
            }
            if(bookingFromDb!.Status==StaticDetails.StatusCheckedIn)
            {
                bookingFromDb.ActualCheckInDate=DateTime.Now;
            }

            if(bookingFromDb.Status==StaticDetails.StatusCompleted)
            {
                bookingFromDb.ActualCheckOutDate = DateTime.Now;
            }
        }

        public void UpdateStripePaymentId(int bookingId, string SeesionId, string PaymentIntentId)
        {
            Booking bookingFromDb = _Db.Bookings.FirstOrDefault(b => b.Id == bookingId)!;
            if(!string.IsNullOrEmpty(SeesionId))
            {
                bookingFromDb.StripeSessionId= SeesionId;
            }

            if(!string.IsNullOrEmpty(PaymentIntentId))
            {
                bookingFromDb.StripePaymentIntentId= PaymentIntentId;
                bookingFromDb.PaymentDate= DateTime.Now;
                bookingFromDb.IsPaymentSuccessfull= true;
            }
        }
    }
}
