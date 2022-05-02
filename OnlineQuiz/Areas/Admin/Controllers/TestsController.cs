using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Infrastructures;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TestsController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }

        public TestsController(QuizDbContext context, INotyfService NotyfService)
        {
            this.context = context;
            this.NotyfService = NotyfService;
        }

        [Route("/admin/bai-thi")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = context.Tests.Include(c=>c.Course);
                ViewBag.Count = await list.CountAsync();
                return View(await list.ToListAsync());
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [Route("/admin/bai-thi/tao-moi")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(context.Courses, "CourseId", "CourseName");
            return View();
        }

        [Route("/admin/bai-thi/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Test test)
        {
            ViewBag.Courses = new SelectList(context.Courses, "CourseId", "CourseName");
            try
            {
                if (ModelState.IsValid)
                {
                    test.TestId = Guid.NewGuid();
                    context.Add(test);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Tạo thành công");
                    return RedirectToAction("Index", "Tests", new { area = "Admin" });
                }
                return View(test);
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [Route("/admin/bai-thi/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Courses = new SelectList(context.Courses, "CourseId", "CourseName");
            var exist = await context.Tests.FindAsync(id);
            if(exist != null)
            {
                return View(exist);
            }
            return NotFound();
        }


        [Route("/admin/bai-thi/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Test test)
        {
            ViewBag.Courses = new SelectList(context.Courses, "CourseId", "CourseName");
            try
            {
                if (ModelState.IsValid)
                {
                    test.TestId = id;
                    context.Update(test);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Sửa thành công");
                    return RedirectToAction("Index", "Tests", new { area = "Admin"});
                }
                return View(test);
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }


        [Route("/admin/bai-thi/xoa/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, Guid? Cid)
        {
            try
            {
                var exist = await context.Tests.FindAsync(Id);
                if (exist != null)
                {
                    context.Remove(exist);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Xóa thành công");
                    if (Cid != null) return Redirect($"/admin/bai-thi/hien-thi-theo-mon/{Cid}");
                    return RedirectToAction("Index", "Tests", new { area = "Admin" });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi : {ex.Message}");
                throw;
            }
        }

        [Route("/admin/bai-thi/hien-thi-theo-mon/{id}")]
        public async Task<IActionResult> DisplayByCourse(Guid id)
        {
            try
            {
                var courses = context.Tests.Include(c => c.Course).Where(x => x.CourseId == id);
                ViewBag.Count = await courses.CountAsync();
                return View(await courses.ToListAsync());
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }
    }
}
