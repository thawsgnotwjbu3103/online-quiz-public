using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Infrastructures;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ClassesController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }

        public ClassesController(QuizDbContext context, 
            INotyfService NotyfService)
        {
            this.context = context;
            this.NotyfService = NotyfService;
        }
        
        [Route("/admin/lop")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = context.Classes.Include(d => d.Department);
                ViewBag.Count = await list.CountAsync();
                return View(await list.ToListAsync());
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [Route("/admin/lop/tao-moi")]
        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.Department = new SelectList(context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [Route("/admin/lop/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Class newClass)
        {
            ViewBag.Department = new SelectList(context.Departments, "DepartmentId", "DepartmentName");
            if (ModelState.IsValid)
            {
                try
                {
                    newClass.ClassId = Guid.NewGuid();
                    var exist = await context.Classes
                    .Include(d => d.Department)
                    .Where(x => x.ClassName.Trim() == newClass.ClassName.Trim())
                    .FirstOrDefaultAsync();

                    if (exist != null)
                    {
                        NotyfService.Error("Dữ liệu bị trùng");
                        return View(newClass);
                    }
                    context.Add(newClass);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Tạo thành công");
                    return RedirectToAction("Index", "Classes", new { area = "Admin" });
                    
                }
                catch (Exception ex)
                {
                    NotyfService.Error("Lỗi :" + ex.Message);
                    throw;
                }
            }
            return View(newClass);
        }

        [Route("/admin/lop/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    ViewBag.Department = new SelectList(context.Departments, "DepartmentId", "DepartmentName");
                    var exist = await context.Classes.FindAsync(Id);
                    if (exist == null) return NotFound();
                    return View(exist);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [Route("/admin/lop/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, Class oldClass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Department = new SelectList(context.Departments, "DepartmentId", "DepartmentName");

                    var exist = await context.Classes
                    .Include(d => d.Department)
                    .Where(x => x.ClassName.Trim() == oldClass.ClassName.Trim() && x.DepartmentId == oldClass.DepartmentId)
                    .FirstOrDefaultAsync();

                    if(exist != null)
                    {
                        NotyfService.Error("Dữ liệu bị trùng");
                        return View(oldClass);
                    }

                    oldClass.ClassId = Id;
                    context.Update(oldClass);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Cập nhập thành công");
                    return RedirectToAction("Index", "Classes", new { area = "Admin"});
                }
                catch (Exception ex)
                {
                    NotyfService.Error("Lỗi: " + ex.Message);
                    throw;
                }
            }
            return View(oldClass);
        }

        [Route("/admin/lop/xoa/{id}")]
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid? Id, Guid? Did)
        {
            try
            {
                if (Id != null)
                {
                    var exist = await context.Classes.FindAsync(Id);
                    if (exist == null) return NotFound();
                    context.Remove(exist);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Xóa thành công");
                    if(Did != null)
                    {
                        return Redirect($"/admin/lop/hien-thi-theo-khoa/{Did}");
                    }
                    return RedirectToAction("Index", "Classes", new { area = "Admin" });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [Route("/admin/lop/hien-thi-theo-khoa/{id}")]
        public async Task<IActionResult> DisplayByDepartment(Guid Id)
        {
            try
            {
                var list = context.Classes.Include(d => d.Department).Where(x => x.DepartmentId == Id);
                ViewBag.Count = await list.CountAsync();
                return View(await list.ToListAsync());
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }
    }
}
