using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;

namespace eVillaBooking.Infrastructure.Repositroy
{
    public class VillaNumberRepository: Repositroy<VillaNumber>, IVillaNumberRepository

    {
        private readonly ApplicationDbContext _Db;
        public VillaNumberRepository(ApplicationDbContext Db) :base(Db)
        {
            _Db = Db;
        }

        
        public void Update(VillaNumber villaNumber)
        {
            _Db.Update(villaNumber);
        }

        
    }
}
