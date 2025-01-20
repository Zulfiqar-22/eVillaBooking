using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Infrastructure.Repositroy
{
    public class Repositroy<T> : IRepositroy<T> where T : class

    {
        private readonly ApplicationDbContext _Db;

        public Repositroy(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public void Add(T entity)
        {
            
            _Db.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _Db.Set<T>().Remove(entity);
        }
        public T Get(Expression<Func<T, bool>> filter, string? Includeproperty = null)
        {
            IQueryable<T> query =_Db.Set<T>();

            query = query.Where(filter);


            if (Includeproperty is not null)
                foreach (var property in Includeproperty.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }


            return query.FirstOrDefault()!;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? Includeproperty = null)
        {
            IQueryable<T> query = _Db.Set<T>();
            if (filter is not null)
            { query = query.Where(filter); }

            if (Includeproperty is not null)
                foreach (var property in Includeproperty.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }

            return query.ToList();

        }


    }
}
