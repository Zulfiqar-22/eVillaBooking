using eVillaBooking.Domain.Entity;
using System.Linq.Expressions;

namespace eVillaBooking.Application.Common.Interfaces
{
	public interface IVillaRepository

	{
		IEnumerable<Villas> GetAll(Expression<Func<Villas, bool>>? filter = null, string? includeproperty=null);

		Villas Get(Expression<Func<Villas,bool>>filter, string? includeproperty=null);

		void Add(Villas villa);
		void Update(Villas villa);
		void Remove(Villas villa);
		void Save(Villas villa);
	}
}
	