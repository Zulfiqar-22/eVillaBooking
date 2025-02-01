using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace eVillaBooking.Presentation.Controllers
{
	public class Villa : Controller
	{
		//private readonly ApplicationDbContext _Db;
		//private readonly IVillaRepository _VillaRepository;
		private readonly Iunitofwork _iunitofwork;
		private readonly IWebHostEnvironment _webHostEnvironment;
        public Villa(Iunitofwork iunitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _iunitofwork = iunitofwork;
			_webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
		{
			//return View(_Db.villa.ToList());
			return View(_iunitofwork.villaRepositoryUOW.GetAll());
		}


		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Villas villa)
		{ 
			
			
			if(villa.Name==villa.Description)
			{
				ModelState.AddModelError("", "Name Description are Same ");
			}
			
			if (ModelState.IsValid)
			{
				if (villa.Image is not null)
				{
					string webRootPath = _webHostEnvironment.WebRootPath;

					string imagePath = Path.Combine(webRootPath, @"Images\VillaImages");

					string newFileName = villa.Image.FileName.Split('.')[0] + "_" + Guid.NewGuid()
										 .ToString().Substring(0, 5) + Path.GetExtension(villa.Image.FileName);

					string finalImagePath = Path.Combine(imagePath, newFileName);

					using (FileStream fileStream = new FileStream(finalImagePath, FileMode.Create))
					{
						villa.Image.CopyTo(fileStream);

						villa.ImageUrl = Path.Combine(@"\Images\VillaImages", newFileName);
					}

				}
				else
				{
					villa.ImageUrl = "www.dummy.com";
				}


				//_Db.villa.Add(villa);
				_iunitofwork.villaRepositoryUOW.Add(villa);
				//_Db.SaveChanges();
				_iunitofwork.Save();
				TempData["SuccessMassage"] = "Villa Add SuccessfUlly!";
				return RedirectToAction(nameof(Index));
			}
			return PartialView("_ValidationScriptsPartial");
		}

		public IActionResult Edit(int id)
		{
			//var EditRecord=_Db.villa.FirstOrDefault(vn=>vn.Id==id);
			
			var EditRecord = _iunitofwork.villaRepositoryUOW.Get(vn => vn.Id == id);
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
				if (villa.Image is not null)
				{
					string webRootPath = _webHostEnvironment.WebRootPath;

					string imagePath = Path.Combine(webRootPath, @"Images\VillaImages");

					string newFileName = villa.Image.FileName.Split('.')[0] + "_" + Guid.NewGuid()
										 .ToString().Substring(0, 5) + Path.GetExtension(villa.Image.FileName);

					string finalImagePath = Path.Combine(imagePath, newFileName);

					if (!string.IsNullOrEmpty(villa.ImageUrl))
					{
						string oldImagePath = Path.Combine(webRootPath, villa.ImageUrl.TrimStart('\\'));

						if(System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}

					}

					using (FileStream fileStream = new FileStream(finalImagePath, FileMode.Create))
					{
						villa.Image.CopyTo(fileStream);

						villa.ImageUrl = Path.Combine(@"\Images\VillaImages", newFileName);
					}

				}


				//_Db.villa.Update(villa);
				_iunitofwork.villaRepositoryUOW.Update(villa);
				//_Db.SaveChanges();
				_iunitofwork.Save();
                TempData["SuccessMassage"] = "Villa Edit SuccessfUlly!";
                return RedirectToAction(nameof(Index));
			}
			return View(villa);
		}

	 public IActionResult Delete(int id)
		{
			//var DeleteRecord = _Db.villa.Find(id);
			var DeleteRecord=_iunitofwork.villaRepositoryUOW.Get(vn=> vn.Id == id);
			if(DeleteRecord is null)
			{
				return NotFound(nameof(Index));
			}
			return View("Delete",DeleteRecord);

		}
		
		public IActionResult DeleteConfirm(int id)
		{
			var villa =_iunitofwork.villaRepositoryUOW.Get(vn=>vn.Id==id);

			string webRootPath = _webHostEnvironment.WebRootPath;

			if (!string.IsNullOrEmpty(villa.ImageUrl))
			{
				string oldImagePath = Path.Combine(webRootPath, villa.ImageUrl.TrimStart('\\'));

				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}

			}

			//var deleterecord=_Db.villa.Find(id);
			//_Db.villa.Remove(deleterecord);
			_iunitofwork.villaRepositoryUOW.Remove(villa);
			_iunitofwork.Save();
            TempData["SuccessMassage"] = "Villa Delete SuccessfUlly!";
            return RedirectToAction(nameof(Index));
		}
	
	
	
	
	
	}
}
