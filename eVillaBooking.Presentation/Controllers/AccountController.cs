using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Application.Utility;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Presentation.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
     public IActionResult Register(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");


            if (!_rolemanager.RoleExistsAsync(StaticDetails.Role_Admin).GetAwaiter().GetResult())
            {
                _rolemanager.CreateAsync(new IdentityRole(StaticDetails.Role_Admin)).Wait();
                _rolemanager.CreateAsync(new IdentityRole(StaticDetails.Role_Customer)).Wait();
            }

                RegisterVM registerVM = new RegisterVM()
            {
               RoleList = _rolemanager.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name })
               ,RedirectURL = returnUrl
            };
            return View(registerVM);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            ApplicationUser user = new ApplicationUser()
            {
                Name = registerVM.Name,
                CreateAt = DateTime.Now,
                Email = registerVM.Email,
                EmailConfirmed = true,
                NormalizedEmail = registerVM.Email.ToUpper(),
                PhoneNumber = registerVM.PhoneNumber,
                UserName = registerVM.Email
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(registerVM.Role))
                    await _userManager.AddToRoleAsync(user, registerVM.Role);

                else
                    await _userManager.AddToRoleAsync(user, StaticDetails.Role_Customer);

                await _signInManager.SignInAsync(user, isPersistent: false);


                if (string.IsNullOrEmpty(registerVM.RedirectURL))
                    return RedirectToAction("index", "home");

                else return LocalRedirect(registerVM.RedirectURL);



            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            registerVM.RoleList = _rolemanager.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name });

            return View(registerVM);

        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            LoginVM loginVM = new LoginVM()
            {
                RedirectURL = returnUrl
            };
            return View(loginVM);
        }
    
     public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.Email,
                                                                    loginVM.Password,
                                                                    isPersistent: loginVM.RememberMe,
                                                                    lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    return string.IsNullOrEmpty(loginVM.RedirectURL)?
                                         RedirectToAction("Index","Home"):
                                         LocalRedirect(loginVM.RedirectURL);
                }
                ModelState.AddModelError("", "Invalid Login Attemp");
            }
            return View(loginVM);
     }
     public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



    }


}
