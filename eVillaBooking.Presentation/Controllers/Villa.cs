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
		public IActionResult Create(Villas villa)
		{ if(villa.Name==villa.Description)
			{
				ModelState.AddModelError("", "Name Description are Same ");
			}
			
			if (ModelState.IsValid)
			{
				_Db.villa.Add(villa);
				_Db.SaveChanges();
				TempData["SuccessMassage"] = "Villa Add SuccessfUlly!";
				return RedirectToAction(nameof(Index));
			}
			return PartialView("_ValidationScriptsPartial");
		}

		public IActionResult Edit(int id)
		{
			var EditRecord=_Db.villa.Find(id);
			if(EditRecord == null)
			{
				return RedirectToAction("error","home");//Error Show RootFile
			}
			return View(EditRecord);
		}
		[HttpPost]
		public IActionResult Edit(Villas villa)
		{
			if (ModelState.IsValid)
			{
				_Db.villa.Update(villa);
				_Db.SaveChanges();
                TempData["SuccessMassage"] = "Villa Edit SuccessfUlly!";
                return RedirectToAction(nameof(Index));
			}
			return View(villa);
		}

	 public IActionResult Delete(int id)
		{
			var DeleteRecord = _Db.villa.Find(id);
			if(DeleteRecord is null)
			{
				return NotFound(nameof(Index));
			}
			return View("Delete",DeleteRecord);

		}
		
		public IActionResult DeleteConfirm(int id)
		{
			var deleterecord=_Db.villa.Find(id);
			_Db.villa.Remove(deleterecord);
			_Db.SaveChanges();
            TempData["SuccessMassage"] = "Villa Delete SuccessfUlly!";
            return RedirectToAction(nameof(Index));
		}
	
	
	
	
	
	}
}
