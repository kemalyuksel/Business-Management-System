using System;
using System.Threading.Tasks;
using Management.Business.Abstract;
using Management.Dto.DTOs.AppUserDTOs;
using Management.Entities.Concrete;
using Management.Web.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _customLogger;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ICustomLogger customLogger) : base(userManager)
        {
            _signInManager = signInManager;
            _customLogger = customLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    AddError(addRoleResult.Errors);
                }

                AddError(result.Errors);

            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        if (userRoles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");

            }


            return View("Index", model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {

            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa Bulunamadı";
            }

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _customLogger.LogError($"\nHatanın oluştuğu yer :{exceptionHandler.Path}\n Hata mesajı : {exceptionHandler.Error.Message}" +
                $"\n Stack Trace {exceptionHandler.Error.StackTrace}\n"); 

            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;

            return View();
        }

    }
}