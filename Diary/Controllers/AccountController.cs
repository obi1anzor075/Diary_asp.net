using Diary.Models;
using Diary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Diary.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                //login
               var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
            
               if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неудачная попытка входа");
                return View(model);
            }
            return View(model);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Registration(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Adress = model.Adress,
                };

                var result = await userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");        
        }
    }
}
