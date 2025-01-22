namespace eVillaBooking.Application.Common.Interfaces
{
    public interface Iunitofwork
    {
        public IVillaRepository villaRepositoryUOW { get; }

        public IVillaNumberRepository villaNumberRepositoryUOW { get; }

        public void Save();

    }
}
