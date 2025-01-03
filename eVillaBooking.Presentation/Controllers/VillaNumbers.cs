﻿using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eVillaBooking.Presentation.Controllers
{
    public class VillaNumbers : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaNumbers(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villanumber=_db.VillaNumbers.Include(n=>n.Villas).ToList();
            return View(villanumber);
        }
      public IActionResult Create()
        {
            List<Villas> villas = _db.villa.ToList();
            IEnumerable<SelectListItem> selectListItems = villas.Select(v => new SelectListItem
            { Text = v.Name, Value = v.Id.ToString() });

            ViewData["SelectListItems"]= selectListItems;
            return View();
        
        }
        [HttpPost]
     public IActionResult Create (VillaNumber villaNumber)
     { var errorMessage = _db.VillaNumbers.Any(v => v.Villa_Number == villaNumber.Villa_Number);

			
			if (ModelState.IsValid && !errorMessage)
			{
				_db.VillaNumbers.Add(villaNumber);
				_db.SaveChanges();
                TempData["SuccessMassage"] = "Villa Number Add Successfully!";
                return RedirectToAction(nameof(Index));
			}

            var SelectListItems=_db.villa.Select(v=> new SelectListItem { Value = v.Id.ToString(), Text=v.Name}).ToList();

            ViewData["SelectListItems"]= SelectListItems;
            TempData["ErorrMessage"] ="villa number already exists";
            return View(villaNumber);

     }
     
     public IActionResult Edit(int id)
        {
            var EditRecord = _db.VillaNumbers.Find(id);
            
            return View(EditRecord);

        }

        [HttpPost]
        public IActionResult Edit(VillaNumber villaNumber)
        
        
        {
            if (ModelState.IsValid)
            {
                _db.VillaNumbers.Update(villaNumber);
                _db.SaveChanges();
				TempData["SuccessMassage"] = "Villa Number Update Successfully!";
				return RedirectToAction(nameof(Index));
            }
            var SelectListItems=_db.villa.Select(v=> new SelectListItem { Value=v.Id.ToString(), Text= v.Name}).ToList();
            ViewData["SelectListItems"]= SelectListItems;

            return View(villaNumber);
        }



    }
}
