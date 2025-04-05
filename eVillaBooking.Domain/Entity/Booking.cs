using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Domain.Entity
{
    public class Booking
    {
        public int Id { get; set; }//primary key

        public ApplicationUser User { get; set; }//navigation prop for the booking entity
        
        
        [Required,ForeignKey(nameof(User))]
        public string UserId {  get; set; }//foregin for the user

        public Villas Villas { get; set; }//navigation prop for the villa booking



        [Required,ForeignKey(nameof(Villas))]
        public int VillasId { get;set; }//foregin key for the villa 

        [Required]
        public string Name {  get; set; }//name of the person for the booking

        [Required]
        public string Email {  get; set; }//email for the person booking villa
         
        public string? Phone {  get; set; }//optional
                                           

        [Required]
        public double TotalCost {  get; set; }//total cost for booking 

        public int Nights {  get; set; }//number of night of villa 

        public string? Status {  get; set; }//status of booking (eg.confirm,pending,cancell)

        [Required]
        public DateTime BookingDate { get; set; }//date was booking 

        [Required]
        public DateOnly CheckInDate { get; set; }

        public DateOnly CheckoutDate { get; set; }
   
     public bool IsPaymentSuccessfull {  get; set; }=false;

        public DateTime PaymentDate { get; set; }//date of successfull payment 

        public string? StripeSessionId {  get; set; }//stripesessionId 

        public string? StripePaymentIntentId { get; set; }//Intent Id tracing tracstion  

        public DateTime ActualCheckInDate { get; set; }
        public DateTime ActualCheckOutDate { get; set; }


        public int VillaNumber {  get; set; }

    }
}
