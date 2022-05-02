using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotifyService { get; }

        public DepartmentsController(QuizDbContext context, INotyfService NotifyService)
        {
            this.context = context;
            this.NotifyService = NotifyService;
        }

        [Route("/admin/khoa")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = context.Departments;
                ViewBag.Count = await list.CountAsync();
                return View(await list.ToListAsync());
            }
            catch (Exception ex)
            {
                NotifyService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [Route("/admin/khoa/tao-moi")]
        [HttpGet]
        public IActionResult Create() => View();

        [Route("/admin/khoa/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    department.DepartmentId = Guid.NewGuid();
                    var exist = await context.Departments
                        .Where(x => x.DepartmentName.Trim() == department.DepartmentName.Trim())
                        .FirstOrDefaultAsync();
                    if (exist != null)
                    {
                        NotifyService.Error("Dữ liệu bị trùng");
                        return View(department);
                    }
                    context.Add(department);
                    await context.SaveChangesAsync();
                    NotifyService.Success("Tạo thành công");
                    return RedirectToAction("Index", "Departments", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    NotifyService.Error("Lỗi :" + ex.Message);
                    throw;
                }
            }
            return View(department);
        }

        [Route("/admin/khoa/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                if (id != null)
                {
                    var department = await context.Departments.FindAsync(id);
                    if (department == null) return NotFound();
                    return View(department);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotifyService.Error("Lỗi :" + ex.Message);
                throw;
            }
        }

        [Route("/admin/khoa/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    department.DepartmentId = id;
                    context.Update(department);
                    await context.SaveChangesAsync();
                    NotifyService.Success("Cập nhập thành công");
                    return RedirectToAction("Index", "Departments", new { area = "Admin" });
                }
                catch (Exception ex)
                {
                    NotifyService.Error("Lỗi :" + ex.Message);
                    throw;
                }
            }
            return View(department);
        }

        [Route("/admin/khoa/xoa/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    var department = await context.Departments.FindAsync(Id);
                    if (department != null)
                    {
                        context.Remove(department);
                        await context.SaveChangesAsync();
                        NotifyService.Success("Xóa thành công");
                        return RedirectToAction("Index", "Departments", new { area = "Admin" });
                    }
                    return NotFound();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotifyService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }
    }
}
