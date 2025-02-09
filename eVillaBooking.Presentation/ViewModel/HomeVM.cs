using eVillaBooking.Domain.Entity;

namespace eVillaBooking.Presentation.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Villas>? VillaList { get; set; }

        public int Night {  get; set; }

        public DateOnly CheckInDate { get; set; }

        public DateOnly CheckOutDate { get; set; }
    }
}
