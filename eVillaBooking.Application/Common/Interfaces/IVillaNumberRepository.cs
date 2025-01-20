using eVillaBooking.Domain.Entity;

namespace eVillaBooking.Application.Common.Interfaces
{
    public interface IVillaNumberRepository :IRepositroy<VillaNumber>
    {
        public void Save();

        public void Update(VillaNumber villaNumber);
    }
}
