using AspNetCoreHero.ToastNotification.Abstractions;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Helpers;
using OnlineQuiz.Infrastructures;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class StudentsController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }
        public IWebHostEnvironment HostingEnvironment { get; set; }

        public StudentsController(QuizDbContext context,
            INotyfService NotyfService,
            IWebHostEnvironment HostingEnvironment)
        {
            this.context = context;
            this.NotyfService = NotyfService;
            this.HostingEnvironment = HostingEnvironment;
        }

        [Route("/admin/hoc-sinh")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = context.Students.Include(c => c.Class);
                ViewBag.Count = await list.CountAsync();
                return View(await list.ToListAsync());
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi" + ex.Message);
                throw;
            }
        }

        [Route("/admin/hoc-sinh/tao-moi")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
            ViewBag.Gender = new SelectList(new List<SelectListItem> {
                new SelectListItem{ Text = "Nam" , Value = "true"},
                new SelectListItem{ Text = "Nữ" , Value = "false"}
            }, "Value", "Text");
            return View();
        }

        [Route("/admin/hoc-sinh/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
            ViewBag.Gender = new SelectList(new List<SelectListItem> {
                        new SelectListItem{ Text = "Nam" , Value = "true"},
                        new SelectListItem{ Text = "Nữ" , Value = "false"}
                    }, "Value", "Text");
            if (ModelState.IsValid)
            {
                try
                {
                    var std = await context.Students
                        .Where(x => x.PhoneNumber == student.PhoneNumber)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                    if(std == null)
                    {
                        student.StudentId = Guid.NewGuid();
                        context.Add(student);
                        await context.SaveChangesAsync();
                        NotyfService.Success("Tạo mới thành công");
                        return RedirectToAction("Index", "Students", new { area = "Admin" });
                    }
                    NotyfService.Error("Số điện thoại đã có người sử dụng");
                    return View(student);
                }
                catch (Exception ex)
                {
                    NotyfService.Error("Lỗi :" + ex.Message);
                    return View(student);
                }
            }
            return View(student);
        }

        [Route("/admin/hoc-sinh/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? Id)
        {
            ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
            ViewBag.Gender = new SelectList(new List<SelectListItem> {
                    new SelectListItem{ Text = "Nam" , Value = "true"},
                    new SelectListItem{ Text = "Nữ" , Value = "false"}
                }, "Value", "Text");

            try
            {
                if (Id != null)
                {
                    var exist = await context.Students.FindAsync(Id);
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

        [Route("/admin/hoc-sinh/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, Student student)
        {
            try
            {
                ViewBag.Class = new SelectList(context.Classes, "ClassId", "ClassName");
                ViewBag.Gender = new SelectList(new List<SelectListItem> {
                    new SelectListItem{ Text = "Nam" , Value = "true"},
                    new SelectListItem{ Text = "Nữ" , Value = "false"}
                }, "Value", "Text");

                if (ModelState.IsValid)
                {
                    student.StudentId = Id;
                    context.Update(student);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Cập nhật thành công");
                    return RedirectToAction("Index", "Students", new { area = "Admin" });
                }
                return View(student);
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [Route("/admin/hoc-sinh/xoa/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid Id, Guid? Cid)
        {
            try
            {
                var student = await context.Students.FindAsync(Id);
                if (student == null) return NotFound();
                context.Remove(student);
                await context.SaveChangesAsync();
                NotyfService.Success("Xóa thành công");
                if (Cid != null) return Redirect($"/admin/hoc-sinh/hien-thi-theo-lop/{Cid}");
                return RedirectToAction("Index", "Students", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi :" + ex.Message);
                throw;
            }
        }

        [Route("/admin/hoc-sinh/hien-thi-theo-lop/{id}")]
        public async Task<IActionResult> DisplayByClass(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    var list = context.Students
                        .Include(c => c.Class)
                        .Where(x => x.ClassId == Id);

                    ViewBag.Count = await list.CountAsync();
                    return View(await list.ToListAsync());
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportStudents(IFormFile file)
        {
            try
            {
                string fileName = $"{HostingEnvironment.WebRootPath}\\files\\excel\\{file.FileName}";
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    await fs.FlushAsync();
                }

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            var departmentValue = reader.GetValue(6);
                            var classValue = reader.GetValue(5);
                            var studentName = reader.GetValue(0).ToString();
                            var departmentContext = context.Departments;
                            var classContext = context.Classes;

                            var existDepartment = await departmentContext
                            .Where(x => x.DepartmentName.ToLower().Trim() == departmentValue.ToString().ToLower().Trim())
                            .FirstOrDefaultAsync();

                            if (existDepartment == null)
                            {
                                var d = new Department
                                {
                                    DepartmentId = Guid.NewGuid(),
                                    DepartmentName = departmentValue.ToString(),
                                };
                                context.Departments.Add(d);
                                await context.SaveChangesAsync();
                            }

                            var existClass = await classContext
                            .Where(x => x.ClassName.ToLower().Trim() == classValue.ToString().ToLower().Trim())
                            .FirstOrDefaultAsync();

                            if (existClass == null)
                            {
                                var c = new Class
                                {
                                    ClassId = Guid.NewGuid(),
                                    ClassName = classValue.ToString(),
                                    DepartmentId = await departmentContext
                                    .Where(x => x.DepartmentName.ToLower().Trim() == departmentValue.ToString().ToLower().Trim())
                                    .AsNoTracking()
                                    .Select(i => i.DepartmentId)
                                    .FirstOrDefaultAsync()
                                };
                                classContext.Add(c);
                                await context.SaveChangesAsync();
                            }

                            var student = await context.Students
                                .Where(x => x.FullName.Trim().ToLower() == studentName.ToLower().Trim())
                                .FirstOrDefaultAsync();

                            if (student == null)
                            {
                                var s = new Student
                                {
                                    StudentId = Guid.NewGuid(),
                                    FullName = reader.GetValue(0).ToString(),
                                    Birthday = reader.GetValue(1).ToString(),
                                    Gender = reader.GetValue(2).ToString() == "Nam",
                                    Address = reader.GetValue(3).ToString(),
                                    PhoneNumber = reader.GetValue(4).ToString(),
                                    ClassId = await classContext
                                    .Where(x => x.ClassName.ToLower().Trim() == classValue.ToString().ToLower().Trim())
                                    .AsNoTracking()
                                    .Select(x => x.ClassId)
                                    .FirstOrDefaultAsync()
                                };

                                context.Students.Add(s);
                                await context.SaveChangesAsync();
                            }
                        }
                    }
                }
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                NotyfService.Success("Import thành công");
                return RedirectToAction("Index", "Students", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }

        [Route("/admin/hoc-sinh/xuat-file/{id?}")]
        public async Task<IActionResult> ExportCsv(Guid? id)
        {
            try
            {
                var builder = new StringBuilder();
                builder.AppendLine("Ten sinh vien,Ngay sinh,Gioi tinh,Dia chi,SDT,Lop,Khoa");
                var studentContext = context.Students.Include(c => c.Class).ThenInclude(d => d.Department);
                var students = id == null ? await studentContext.ToListAsync() : await studentContext.Where(x => x.ClassId == id).ToListAsync();

                foreach (var student in students)
                {
                    var gender = student.Gender == true ? "Nam" : "Nữ";
                    var birthday = DateTime.Parse(student.Birthday).ToString("dd/MM/yyyy");
                    var str = $"{student.FullName},{birthday},{gender},{student.Address}," +
                        $"{student.PhoneNumber},{student.Class.ClassName},{student.Class.Department.DepartmentName}";
                    builder.AppendLine(str);
                }

                var fileName = $"dssv_all_{DateTime.Now.ToString("ddMMyyyy")}.csv";

                if (id != null)
                {
                    var className = await context.Classes.Where(x => x.ClassId == id).Select(x => x.ClassName).FirstOrDefaultAsync();
                    fileName = $"dssv_{Utilities.convertToUnSign(className).Replace(" ", String.Empty).ToLower()}_{DateTime.Now.ToString("ddMMyyyyy")}.csv";
                }

                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", fileName);
            }
            catch (Exception ex)
            {
                NotyfService.Error("Lỗi: " + ex.Message);
                throw;
            }
        }
    }
}
