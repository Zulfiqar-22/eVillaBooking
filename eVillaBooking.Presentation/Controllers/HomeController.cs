using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Presentation.Models;
using eVillaBooking.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eVillaBooking.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly Iunitofwork _unitofwork;

		public HomeController(Iunitofwork unitofwork)
		{
		 _unitofwork = unitofwork;	
		}

		public IActionResult Index()
		{
			HomeVM homeVM = new HomeVM()
			{
				VillaList = _unitofwork.villaRepositoryUOW.GetAll(Includeproperty: "AmenitiesList"),
				Night = 1,
				CheckInDate = DateOnly.FromDateTime(DateTime.Now)
			};
			return View(homeVM);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View();
		}
	}
}
