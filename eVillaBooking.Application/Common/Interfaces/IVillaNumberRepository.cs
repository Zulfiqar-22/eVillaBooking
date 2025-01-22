using eVillaBooking.Domain.Entity;

namespace eVillaBooking.Application.Common.Interfaces
{
    public interface IVillaNumberRepository :IRepositroy<VillaNumber>
    {

        public void Update(VillaNumber villaNumber);
    }
}
