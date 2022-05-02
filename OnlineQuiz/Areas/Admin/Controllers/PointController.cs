using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PointController : Controller
    {
        
        private readonly QuizDbContext context;
        public PointController(QuizDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/admin/diem/{courseId?}")]
        public async Task<IActionResult> Index(Guid? courseId)
        {
            ViewBag.Course = new SelectList(context.Courses, "CourseId", "CourseName");
            var point = await context.Points
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Include(t => t.Test)
                .AsNoTracking()
                .ToListAsync();

            if(courseId != null)
            {
                point.Where(x => x.CourseId == courseId);
            }

            return View(point);
        }
        
        [HttpGet]
        [Route("/admin/diem/loc/{courseId?}")]
        public IActionResult Filter(Guid? courseId)
        {
            try
            {
                var url = $"/admin/diem?courseId={courseId}";
                if (courseId == Guid.Empty)
                {
                    url = $"/admin/diem";
                }

                return Json(new { status = "success", redirectUrl = url });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Route("/admin/diem/xuat-file")]
        public async Task<IActionResult> ExportCsv()
        {
            try
            {
                var builder = new StringBuilder();
                builder.AppendLine("Ten sinh vien,Bai thi,Mon hoc,Tong diem,Thoi gian nop bai");
                var points = await context.Points
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Include(t => t.Test)
                .AsNoTracking()
                .ToListAsync();

                foreach (var point in points)
                {
                    var str = $"{point.Student.FullName},{point.Test.TestName},{point.Course.CourseName},{point.TotalPoint},{point.AnswerTime}";
                    builder.AppendLine(str);
                }

                var fileName = $"ds_diem_thi_{DateTime.Now.ToString("ddMMyyyy")}.csv";

                return File(Encoding.UTF8.GetBytes(builder.ToString()),"text/csv",fileName);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
