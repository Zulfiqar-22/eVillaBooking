using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Infrastructure.Data;

namespace eVillaBooking.Infrastructure.Repositroy
{
    public class UnitofWork : Iunitofwork
    {
        private readonly ApplicationDbContext _Db;
        public IVillaRepository villaRepositoryUOW { get; private set; }

        public IVillaNumberRepository villaNumberRepositoryUOW { get; private set; }

        public IAmenityRepositroy AmenityRepositroyUOW { get; private set; }

        public IBookingRepositroy BookingRepositroyUow { get; private set; }

        public IApplicationUser ApplicationUserUOW { get; private set; }



        public void Save()
        { _Db.SaveChanges(); }


        public UnitofWork(ApplicationDbContext Db)
        {
            _Db = Db;
            this.villaRepositoryUOW =new VillaRepository (_Db);
            this.villaNumberRepositoryUOW =new VillaNumberRepository (_Db);
            this.AmenityRepositroyUOW=new AmenityRepositroy (_Db);
            this.BookingRepositroyUow = new BookingRepositroy (_Db);
            this.ApplicationUserUOW=new ApplicationUserRepositroy(_Db);
        }
      
    
    
    }
}
