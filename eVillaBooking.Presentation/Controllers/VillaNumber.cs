using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eVillaBooking.Presentation.Controllers
{
    public class VillaNumber : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaNumber(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villanumber=_db.VillaNumbers.Include(n=>n.Villas).ToList();
            return View(villanumber);
        }
     public IActionResult Create(int id)
        {
            List<Villas> villas = _db.villa.ToList();
            IEnumerable<SelectListItem> selectListItems = villas.Select(h => new SelectListItem
            { Text = h.Name, Value = h.Id.ToString() });
            ViewData["SelectListItems"]= selectListItems;
            return View();
        }
    
    
    
    }
}
