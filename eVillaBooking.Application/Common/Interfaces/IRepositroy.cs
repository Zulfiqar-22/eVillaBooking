using System.Linq.Expressions;

namespace eVillaBooking.Application.Common.Interfaces
{
    public interface IRepositroy <T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? Includeproperty = null);

        T Get(Expression<Func<T,bool>> filter,string? Includeproperty = null);

        void Add(T entity);

        void Remove(T entity);

        
    }
}
