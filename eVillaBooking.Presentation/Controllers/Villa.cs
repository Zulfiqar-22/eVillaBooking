using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace eVillaBooking.Presentation.Controllers
{
	public class Villa : Controller
	{
		//private readonly ApplicationDbContext _Db;
		private readonly IVillaRepository _VillaRepository;
        public Villa(IVillaRepository villaRepository)
        {
            _VillaRepository = villaRepository;
        }
        public IActionResult Index()
		{
			//return View(_Db.villa.ToList());
			return View(_VillaRepository.GetAll());
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
				//_Db.villa.Add(villa);
				_VillaRepository.Add(villa);
				//_Db.SaveChanges();
				_VillaRepository.Save();
				TempData["SuccessMassage"] = "Villa Add SuccessfUlly!";
				return RedirectToAction(nameof(Index));
			}
			return PartialView("_ValidationScriptsPartial");
		}

		public IActionResult Edit(int id)
		{
			//var EditRecord=_Db.villa.FirstOrDefault(vn=>vn.Id==id);
			var EditRecord = _VillaRepository.Get(vn => vn.Id == id);
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
				//_Db.villa.Update(villa);
				_VillaRepository.Update(villa);
				//_Db.SaveChanges();
				_VillaRepository.Save();
                TempData["SuccessMassage"] = "Villa Edit SuccessfUlly!";
                return RedirectToAction(nameof(Index));
			}
			return View(villa);
		}

	 public IActionResult Delete(int id)
		{
			//var DeleteRecord = _Db.villa.Find(id);
			var DeleteRecord=_VillaRepository.Get(vn=> vn.Id == id);
			if(DeleteRecord is null)
			{
				return NotFound(nameof(Index));
			}
			return View("Delete",DeleteRecord);

		}
		
		public IActionResult DeleteConfirm(int id)
		{
			//var deleterecord=_Db.villa.Find(id);
			var deleterecord=_VillaRepository.Get(vn=>vn.Id==id);
			//_Db.villa.Remove(deleterecord);
			_VillaRepository.Remove(deleterecord);
			_VillaRepository.Save();
            TempData["SuccessMassage"] = "Villa Delete SuccessfUlly!";
            return RedirectToAction(nameof(Index));
		}
	
	
	
	
	
	}
}
