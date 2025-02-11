using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eVillaBooking.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(Iunitofwork unitofwork,
                                 UserManager<ApplicationUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _unitofwork = unitofwork;
            _userManager = userManager;
            _rolemanager = roleManager;
            _signInManager = signInManager;
            
        }
     public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    
    
    
    }
}
