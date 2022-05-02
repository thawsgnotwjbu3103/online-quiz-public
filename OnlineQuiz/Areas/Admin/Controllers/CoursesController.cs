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
    public class CoursesController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }

        public CoursesController(QuizDbContext context, INotyfService NotyfService)
        {
            this.context = context;
            this.NotyfService = NotyfService;
        }

        [Route("/admin/mon-hoc")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var courses = context.Courses.Include(c=>c.Class);
                ViewBag.Count = await courses.CountAsync();
                return View(await courses.ToListAsync());
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [Route("/admin/mon-hoc/tao-moi")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Class = new SelectList(context.Classes, "ClassId","ClassName");
            return View();
        }

        [Route("/admin/mon-hoc/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course courses)
        {
            try
            {
                ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
                if (ModelState.IsValid)
                {
                    courses.CourseId = Guid.NewGuid();
                    context.Add(courses);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Tạo thành công");
                    return RedirectToAction("Index","Courses", new { area = "Admin"});
                }
                return View(courses);
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [Route("/admin/mon-hoc/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
            var course = await context.Courses.FindAsync(id);
            if(course != null)
            {
                return View(course);
            }
            return NotFound();
        }


        [Route("/admin/mon-hoc/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Course course)
        {
            ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
            try
            {
                if (ModelState.IsValid)
                {
                    var exist = await context.Courses.FindAsync(id);
                    if(exist != null)
                    {
                        course.CourseId = id;
                        context.Update(course);
                        await context.SaveChangesAsync();
                        NotyfService.Success("Sửa thành công");
                        return RedirectToAction("Index", "Courses", new { area = "Admin" });
                    }
                    return View(course);
                }
                return View(course);
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }


        [Route("/admin/mon-hoc/xoa/{id}")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(Guid id, Guid? Cid)
        {
            try
            {
                var exist = await context.Courses.FindAsync(id);
                if (exist != null)
                {
                    context.Remove(exist);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Xóa thành công");
                    if (Cid != null) return Redirect($"/admin/mon-hoc/hien-thi-theo-lop/{Cid}");
                    return RedirectToAction("Index", "Courses", new { area = "Admin" });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [Route("/admin/mon-hoc/hien-thi-theo-lop/{id}")]
        public async Task<IActionResult> DisplayByClass(Guid id)
        {
            try
            {
                var courses = context.Courses.Include(c=>c.Class).Where(x => x.ClassId == id);
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
