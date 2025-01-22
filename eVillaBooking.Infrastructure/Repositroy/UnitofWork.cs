using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Infrastructure.Data;

namespace eVillaBooking.Infrastructure.Repositroy
{
    public class UnitofWork : Iunitofwork
    {
        private readonly ApplicationDbContext _Db;
        public IVillaRepository villaRepositoryUOW { get; private set; }

        public IVillaNumberRepository villaNumberRepositoryUOW { get; private set; }

        public void Save()
        { _Db.SaveChanges(); }


        public UnitofWork(ApplicationDbContext Db)
        {
            _Db = Db;
            this.villaRepositoryUOW =new VillaRepository (_Db);
            this.villaNumberRepositoryUOW =new VillaNumberRepository (_Db);

        }
      
    
    
    }
}
