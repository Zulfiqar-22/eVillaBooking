using eVillaBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Application.Common.Interfaces
{
     public interface IBookingRepositroy : IRepositroy<Booking>
    {
        void Update(Booking booking);

        void UpdateStatus(int bookingId, string bookingStatus);
        void UpdateStripePaymentId(int bookingId, string SeesionId,string PaymentIntentId);

    }
    

    
}
