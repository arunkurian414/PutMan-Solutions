using BOL.Models;
using Flavours_InvMgtPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flavours_InvMgtPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]

        #region Edit Section for Users
        public IActionResult ListUsers()
        {
            var appUsers = userManager.Users;
            return View(appUsers);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessgae = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            var editUserModel = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                UserIdNumber = user.UserIdNumber,
                UserIdType = user.UserIdType,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };
            return View(editUserModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel editUserModel)
        {
            var user = await userManager.FindByIdAsync(editUserModel.Id);
            if (user == null)
            {
                ViewBag.ErrorMessgae = $"Role with Id = {editUserModel.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.UserName = editUserModel.UserName;
                user.UserIdNumber = editUserModel.UserIdNumber;
                user.UserIdType = editUserModel.UserIdType;
                user.Email = editUserModel.Email;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(editUserModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessgae = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var userClaims = await userManager.GetClaimsAsync(user);
                var userRoles = await userManager.GetRolesAsync(user);

                var deleteUserModel = new DeleteUserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    UserIdNumber = user.UserIdNumber,
                    UserIdType = user.UserIdType,
                    Claims = userClaims.Select(c => c.Value).ToList(),
                    Roles = userRoles
                };
                //await userManager.DeleteAsync(user);
                return View(deleteUserModel);

            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserViewModel deleteUserModel)
        {
            var user = await userManager.FindByIdAsync(deleteUserModel.Id);
            if (user == null)
            {
                ViewBag.ErrorMessgae = $"User with Id = {deleteUserModel.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //var deleteUserModel = new DeleteUserViewModel
                //{
                //    Id = user.Id,
                //    UserName = user.UserName,
                //    Email = user.Email,
                //    UserIdNumber = user.UserIdNumber,
                //    UserIdType = user.UserIdType
                //};
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(deleteUserModel);
            }


        }

        #endregion
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = registerModel.Email,
                    Email = registerModel.Email,
                    UserIdNumber = registerModel.UserIdNumber,
                    UserIdType = registerModel.UserIdType
                };
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Account");
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerModel);
        }
        [AllowAnonymous]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
            }
            return View(loginModel);
        }
        [AcceptVerbs("Get", "Set")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use!");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
