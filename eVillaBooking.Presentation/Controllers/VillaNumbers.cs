using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eVillaBooking.Presentation.Controllers
{
    public class VillaNumbers : Controller
    {
        
        private readonly IVillaNumberRepository _numberRepository;
        private readonly IVillaRepository _repository;
        public VillaNumbers(IVillaNumberRepository numberRepository,IVillaRepository repository)
        {
            _numberRepository = numberRepository;
            _repository = repository;
        }
        public IActionResult Index()
        {
            //var villanumber=_db.VillaNumbers.Include(n=>n.Villas).ToList();
            var villanumber = _numberRepository.GetAll(Includeproperty: "Villas");
            return View(villanumber);
        }
      public IActionResult Create()
        {
            //List<Villas> villas = _db.villa.ToList();
            IEnumerable<Villas> villas = _repository.GetAll();
            IEnumerable
                <SelectListItem> selectListItems = villas.Select(v => new SelectListItem
            { Text = v.Name, Value = v.Id.ToString() });

            ViewData["SelectListItems"]= selectListItems;
            return View();
        
        }
        [HttpPost]
     public IActionResult Create (VillaNumber villaNumber)
     { var errorMessage =_numberRepository.GetAll().Any(v => v.Villa_Number == villaNumber.Villa_Number);

			
			if (ModelState.IsValid && !errorMessage)
			{
				_numberRepository.Add(villaNumber);
				_numberRepository.Save();
                TempData["SuccessMassage"] = "Villa Number Add Successfully!";
                return RedirectToAction(nameof(Index));
			}

            var SelectListItems=_repository.GetAll().Select(v=> new SelectListItem { Value = v.Id.ToString(), Text=v.Name}).ToList();

            ViewData["SelectListItems"]= SelectListItems;
            TempData["ErorrMessage"] ="villa number already exists";
            return View(villaNumber);

     }
     
     public IActionResult Edit(int id)
        {
			var EditRecord = _numberRepository.Get(vn=>vn.Villa_Number==id);

			var SelectListItems = _repository.GetAll().Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();
			ViewData["SelectListItems"] = SelectListItems;

            
            return View(EditRecord);

        }

        [HttpPost]
        public IActionResult Edit(VillaNumber villaNumber)
        
        
        {
            if (ModelState.IsValid)
            {
                _numberRepository.Update(villaNumber);
                _numberRepository.Save();
				TempData["SuccessMassage"] = "Villa Number Update Successfully!";
				return RedirectToAction(nameof(Index));
            }
            var SelectListItems=_repository.GetAll().Select(v=> new SelectListItem { Value=v.Id.ToString(), Text= v.Name}).ToList();
            ViewData["SelectListItems"]= SelectListItems;

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            //var villanumber = _db.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == id);
            var villanumber = _numberRepository.Get(vn => vn.Villa_Number == id);
            if(villanumber is null)
            {
                return NotFound();
            }
            //var DeleteRecord = _db.VillaNumbers.Find(id);
            var SelectListItems = _repository.GetAll().Select(vn => new SelectListItem { Value = vn.Id.ToString(), Text = vn.Name });
            ViewData["SelectListItems"] = SelectListItems;
            return View(villanumber);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int villa_number)
        {
            //var DeleteRecord = _db.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == villa_number);
            var DeleteRecord = _numberRepository.Get(vn => vn.Villa_Number == villa_number);
            _numberRepository.Remove(DeleteRecord);
            _numberRepository.Save();
            TempData["ErorrMessage"] = "villa number Delete!";
			return RedirectToAction(nameof(Index));
        }


    }
}
