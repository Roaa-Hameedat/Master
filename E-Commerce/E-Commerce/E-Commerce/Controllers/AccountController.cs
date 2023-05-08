using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                var result = await signInManager.PasswordSignInAsync(model.Email!,
                       model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if(user==null)
                    {
                       
                        return RedirectToAction("Index", "Home");
                    }
                    if (await userManager.IsInRoleAsync(user!, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Invalid user or password");
                return View(model);
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Back()
        {
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (await userManager.IsInRoleAsync(user!, "Admin"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
