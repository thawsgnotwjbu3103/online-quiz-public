using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Infrastructures;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }
        public AccountController(UserManager<AppUser> userManager,
                                QuizDbContext context,
                                INotyfService NotyfService,
                                SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.NotyfService = NotyfService;
            this.signInManager = signInManager;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [Route("/dang-ky")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                }
                return RedirectToAction("Index", "Dashboard", new { area = "" });
            }
            return View();
        }

        [HttpPost]
        [Route("/dang-ky")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user, string phoneNumber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (phoneNumber == null)
                    {
                        NotyfService.Error("Số điện thoại không được để trống");
                        return View(user);
                    }
                    if (phoneNumber.All(char.IsDigit))
                    {
                        var student = await context.Students
                            .Where(x => x.PhoneNumber.Trim() == phoneNumber.Trim())
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

                        var userExist = await context.Users
                            .Include(s => s.Student)
                            .Where(x => x.StudentId == student.StudentId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

                        if (student == null)
                        {
                            NotyfService.Error("Không tìm thấy SDT hợp lệ");
                            return View(user);
                        }

                        if (userExist != null || user.UserName.Trim().ToLower() == "admin")
                        {
                            NotyfService.Error("SDT đang được sử dụng ở một tài khoản khác");
                            return View(user);
                        }

                        AppUser appUser = new AppUser()
                        {
                            UserName = user.UserName,
                            StudentId = student.StudentId
                        };

                        IdentityResult result = await userManager.CreateAsync(appUser, user.Password);


                        if (result.Succeeded)
                        {
                            NotyfService.Success("Tạo tài khoản thành công");
                            var currentUser = await userManager.FindByNameAsync(user.UserName);
                            var roleresult = await userManager.AddToRoleAsync(currentUser, "Student");
                            return RedirectToAction("Login", "Account", new { area = "" });
                        }

                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                return View(user);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("/dang-nhap")]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login
            {
                ReturnUrl = returnUrl
            };
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                return RedirectToAction("Index", "Dashboard", new { area = "" });
            }
            return View(login);
        }

        [HttpPost]
        [Route("/dang-nhap")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AppUser appUser = await userManager.FindByNameAsync(login.UserName);
                    if (appUser != null)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                            .PasswordSignInAsync(appUser, login.Password, false, false);
                        
                        if (result.Succeeded)
                        {
                            return Redirect(login.ReturnUrl ?? "/");
                        }
                        NotyfService.Error("Sai tài khoản hoặc mật khẩu");
                    }
                }
                return View(login);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/dang-xuat")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/dang-nhap");
        }
    }
}
