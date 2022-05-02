using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Infrastructures;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly QuizDbContext context;
        public AccountsController(UserManager<AppUser> userManager, QuizDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        [Route("/admin/tai-khoan")]
        public async Task<IActionResult> Index()
        {
            var users = await context.Users
                .Include(s => s.Student)
                .AsNoTracking()
                .ToListAsync();

            return View(users);
        }
    }
}
