using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace eVillaBooking.Presentation.Controllers
{
	public class Villa : Controller
	{
		private readonly ApplicationDbContext _Db;
        public Villa(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult Index()
		{
			//var listofvilla=_Db.villa.ToList();
			return View(_Db.villa.ToList());
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Villas mood)
		{ if (ModelState.IsValid)
			{
				_Db.villa.Add(mood);
				_Db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(mood);
		}
	}
}
