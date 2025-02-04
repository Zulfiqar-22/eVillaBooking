using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace eVillaBooking.Infrastructure.Repositroy
{
	public class VillaRepository :Repositroy<Villas> ,IVillaRepository
	{   
		private readonly ApplicationDbContext _Db;

        public VillaRepository(ApplicationDbContext Db) :base(Db) 
        {
            _Db = Db;
        }
        
        public void Update(Villas villas)
        {
            _Db.villa.Update(villas);
        }

        
	}
}