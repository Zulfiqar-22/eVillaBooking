using eVillaBooking.Domain.Entity;
using System.Linq.Expressions;

namespace eVillaBooking.Application.Common.Interfaces
{
	public interface IVillaRepository:IRepositroy<Villas>

	{
		
		
		void Update(Villas villa);
		
		void Save();
	}
}
	