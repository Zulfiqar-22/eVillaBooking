using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Application.Utility;

//using eVillaBooking.Application.Utility;
using eVillaBooking.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eVillaBooking.Presentation.Controllers
{
    [Authorize(Roles =StaticDetails.Role_Admin)]
	public class AmenityController : Controller
	{

		//private readonly IVillaNumberRepository _numberRepository;
		//private readonly IVillaRepository _repository;
		private readonly Iunitofwork _unitofAmenity;
		public AmenityController(Iunitofwork unitofAmenity)
		{
			_unitofAmenity = unitofAmenity;
		}
		public IActionResult Index()
		{
			//var villanumber=_db.VillaNumbers.Include(n=>n.Villas).ToList();
			var amenity = _unitofAmenity.AmenityRepositroyUOW.GetAll(Includeproperty: "Villas");
			return View(amenity);
		}
		public IActionResult Create()
		{
			//List<Villas> villas = _db.villa.ToList();
			IEnumerable<Villas> villas = _unitofAmenity.villaRepositoryUOW.GetAll();
			IEnumerable
				<SelectListItem> selectListItems = villas.Select(v => new SelectListItem
				{ Text = v.Name, Value = v.Id.ToString() });

			ViewData["SelectListItems"] = selectListItems;
			return View();

		}
		[HttpPost]
		public IActionResult Create(Amenity amenity)
		{


			if (ModelState.IsValid)
			{
				_unitofAmenity.AmenityRepositroyUOW.Add(amenity);
				_unitofAmenity.Save();
				TempData["SuccessMassage"] = "Villa Amenity Add Successfully!";
				return RedirectToAction(nameof(Index));
			}

			var SelectListItems = _unitofAmenity.villaRepositoryUOW.GetAll().Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();

			ViewData["SelectListItems"] = SelectListItems;
			TempData["ErorrMessage"] = "villa Amenity already exists";
			return View(amenity);

		}

		public IActionResult Edit(int id)
		{
			var EditRecord = _unitofAmenity.AmenityRepositroyUOW.Get(am => am.Id == id);

			var SelectListItems = _unitofAmenity.villaRepositoryUOW.GetAll().Select(v =>
			
			new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();
			ViewData["SelectListItems"] = SelectListItems;


			return View(EditRecord);

		}

		[HttpPost]
		public IActionResult Edit(Amenity amenity)


		{
			if (ModelState.IsValid)
			{
				_unitofAmenity.AmenityRepositroyUOW.Update(amenity);
				_unitofAmenity.Save();
				TempData["SuccessMassage"] = "Villa Amenity Update Successfully!";
				return RedirectToAction(nameof(Index));
			}
			var SelectListItems = _unitofAmenity.villaRepositoryUOW.GetAll().Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();
			ViewData["SelectListItems"] = SelectListItems;

			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int id)
		{
			//var villanumber = _db.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == id);
			var amenity = _unitofAmenity.AmenityRepositroyUOW.Get(am => am.Id== id);
			if (amenity is null)
			{
				return NotFound();
			}
			//var DeleteRecord = _db.VillaNumbers.Find(id);
			var SelectListItems = _unitofAmenity.villaRepositoryUOW.GetAll().Select(vn => new SelectListItem { Value = vn.Id.ToString(), Text = vn.Name });
			ViewData["SelectListItems"] = SelectListItems;
			return View(amenity);
		}
		[HttpPost]
		[ActionName("Delete")]
		public IActionResult DeleteConfirm(int id)
		{
			//var DeleteRecord = _db.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == villa_number);
			var DeleteRecord = _unitofAmenity.AmenityRepositroyUOW.Get(am => am.Id == id);
			_unitofAmenity.AmenityRepositroyUOW.Remove(DeleteRecord);
			_unitofAmenity.Save();
			TempData["ErorrMessage"] = "Villa Amenity Delete!";
			return RedirectToAction(nameof(Index));
		}
		
	}
}
