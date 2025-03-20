namespace eVillaBooking.Application.Common.Interfaces
{
    public interface Iunitofwork
    {
        public IVillaRepository villaRepositoryUOW { get; }

        public IVillaNumberRepository villaNumberRepositoryUOW { get; }

        public IAmenityRepositroy AmenityRepositroyUOW { get; }

        public IBookingRepositroy BookingRepositroyUow { get; }

        public IApplicationUser ApplicationUserUOW { get; }

        public void Save();

    }
}
