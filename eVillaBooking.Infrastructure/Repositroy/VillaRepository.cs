using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace eVillaBooking.Infrastructure.Repositroy
{
	public class VillaRepository : IVillaRepository
	{
		private readonly ApplicationDbContext _Db;

        public VillaRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public void Add(Villas villa)
		{
			_Db.villa.Add(villa);
		}

		public void Remove(Villas villa)
		{
			_Db.villa.Remove(villa);
		}

		public void Save(Villas villa)
		{
			_Db.SaveChanges();
		}

		public void Update(Villas villa)
		{
			_Db.villa.Update(villa);
		}

		public Villas Get(Expression<Func<Villas, bool>> filter, string? includeproperty = null)
		{
			IQueryable<Villas> query = _Db.villa;

			query=query.Where(filter);

			if(includeproperty is not null)
			foreach(var property in includeproperty.Split(',',StringSplitOptions.RemoveEmptyEntries))
				{
					query=query.Include(property);
				}


			return query.FirstOrDefault();
		}

		public IEnumerable<Villas> GetAll(Expression<Func<Villas, bool>>? filter = null, string? includeproperty = null)
		{

			IQueryable<Villas> query= _Db.villa;
			if (filter is not null)
			{ query = query.Where(filter); }

			if (includeproperty is not null)
				foreach (var property in includeproperty.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);
				}

			return query.ToList();



		}


	}
}