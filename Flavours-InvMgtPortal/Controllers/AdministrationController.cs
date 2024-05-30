using BOL.Models;
using Flavours_InvMgtPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flavours_InvMgtPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var createRole = new IdentityRole()
                {
                    Name = roleViewModel.RoleName
                };
                var result = await roleManager.CreateAsync(createRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(roleViewModel);
        }
        [HttpGet]
        public IActionResult ListRole()
        {
            var role = roleManager.Roles;
            return View(role);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessgae = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            var editModel = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users.ToList()) // note: Conversion to list seems mandatory for an Iqueryable Object ;
                                                             // otherwise Entity Framework throws data reader exception as -
                                                             // "InvalidOperationException: There is already an open DataReader associated
                                                             // with this Connection which must be closed first."
                                                             // Besides this solution, MARS-MultipleActiveResultSets=true
                                                             // can be applied in the connection string


            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    editModel.Users.Add(user.UserName);
                }
            }
            return View(editModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editModel)
        {
            var role = await roleManager.FindByIdAsync(editModel.Id);
            if (role == null)
            {
                ViewBag.ErrorMessgae = $"Role with Id = {editModel.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = editModel.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(editModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessgae = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;

                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> userRoleViewModels, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            for (int i = 0; i < userRoleViewModels.Count; i++)
            {
                var user = await userManager.FindByIdAsync(userRoleViewModels[i].UserId);

                IdentityResult result = null;

                if (userRoleViewModels[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!userRoleViewModels[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < userRoleViewModels.Count - 1)
                        continue;
                    else
                    {
                        return RedirectToAction("EditRole", new { id = roleId });
                    }
                }

            }

            return RedirectToAction("EditRole", new { id = roleId });

        }
    }
}
