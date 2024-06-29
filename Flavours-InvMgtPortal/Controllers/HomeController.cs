using BOL.Models;
using Flavours_InvMgtPortal.Models;
using Flavours_InvMgtPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Flavours_InvMgtPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(ILogger<HomeController> logger,  UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //public IActionResult Login_New()
        //{
        //    return View();
        //}
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[AllowAnonymous]
        public IActionResult LoginUser(LoginViewModel loginModel)
        {
            return View();
        }
        //public async Task<IActionResult> Index(LoginViewModel loginModel, string returnUrl = "%2F")
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
        //        if (result.Succeeded)
        //        {
        //            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Home", "Home");
        //            }
        //        }
        //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
        //    }
        //    return View(loginModel);
        //}

        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
