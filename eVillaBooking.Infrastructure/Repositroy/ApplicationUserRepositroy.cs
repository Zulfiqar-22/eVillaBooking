using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVillaBooking.Infrastructure.Repositroy
{
    public class ApplicationUserRepositroy:Repositroy<ApplicationUser>,IApplicationUser
    {
        private readonly ApplicationDbContext _Db;
        public ApplicationUserRepositroy(ApplicationDbContext Db) :base(Db)
        {
            _Db = Db;
            
        }
    }
}
