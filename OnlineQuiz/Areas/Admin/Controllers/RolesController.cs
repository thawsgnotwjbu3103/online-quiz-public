using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public INotyfService NotyfService { get; }

        public RolesController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            INotyfService NotyfService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.NotyfService = NotyfService;
        }

        [Route("/admin/quyen-truy-cap")]
        public IActionResult Index() => View(roleManager.Roles);

        [Route("/admin/quyen-truy-cap/tao-moi")]
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [Route("/admin/quyen-truy-cap/tao-moi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([MinLength(2), Required] string name)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Roles", new { area = "Admin" });
                    }
                }
                NotyfService.Error("Có lỗi xảy ra, vui lòng thử lại sau");
                return View(name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("/admin/quyen-truy-cap/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<AppUser> members = new List<AppUser>();
            List<AppUser> nonMembers = new List<AppUser>();

            foreach (AppUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }


        [HttpPost]
        [Route("/admin/quyen-truy-cap/chinh-sua/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleEdit roleEdit)
        {
            IdentityResult result;
            foreach (var userId in roleEdit.AddIds ?? new string[] { })
            {
                AppUser user = await userManager.FindByIdAsync(userId);
                result = await userManager.AddToRoleAsync(user, roleEdit.RoleName);
            }

            foreach (var userId in roleEdit.DeleteIds ?? new string[] { })
            {
                AppUser user = await userManager.FindByIdAsync(userId);
                result = await userManager.RemoveFromRoleAsync(user, roleEdit.RoleName);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
