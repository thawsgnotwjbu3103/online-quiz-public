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
    public class QuestionChoicesController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }
        public IWebHostEnvironment HostingEnvironment { get; set; }

        public QuestionChoicesController(QuizDbContext context, INotyfService NotyfService,
            IWebHostEnvironment HostingEnvironment)
        {
            this.context = context;
            this.NotyfService = NotyfService;
            this.HostingEnvironment = HostingEnvironment;
        }

        [Route("/admin/tra-loi/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var choices = context.QuestionChoices.Include(q => q.Question);
                ViewBag.Count = await choices.CountAsync();
                return View(await choices.OrderBy(x => x.Question.QuestionTitle).ToListAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/tra-loi/tao-moi")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Question = new SelectList(context.Questions, "QuestionId", "QuestionTitle");
            return View();
        }

        [Route("/admin/tra-loi/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionChoice qChoice)
        {
            ViewBag.Question = new SelectList(context.Questions, "QuestionId", "QuestionTitle");
            try
            {
                if (ModelState.IsValid)
                {
                    qChoice.ChoiceId = Guid.NewGuid();
                    context.Add(qChoice);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Tạo thành công");
                    return RedirectToAction("Index", "QuestionChoices", new { area = "Admin" });
                }
                return View(qChoice);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/tra-loi/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            ViewBag.Question = new SelectList(context.Questions, "QuestionId", "QuestionTitle");
            try
            {
                var exist = await context.QuestionChoices.FindAsync(Id);
                if (exist != null) return View(exist);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/tra-loi/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, QuestionChoice qChoice)
        {
            ViewBag.Question = new SelectList(context.Questions, "QuestionId", "QuestionTitle");
            try
            {
                if (ModelState.IsValid)
                {
                    qChoice.ChoiceId = Id;
                    context.Update(qChoice);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Sửa thành công");
                    return RedirectToAction("Index", "QuestionChoices", new { area = "Admin" });
                }
                return View(qChoice);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid Id, Guid? qId)
        {
            try
            {
                var exist = await context.QuestionChoices.FindAsync(Id);
                if (exist != null)
                {
                    context.Remove(exist);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Xóa thành công");
                    if (qId != null) return Redirect($"/admin/tra-loi/hien-thi-theo-cau-hoi/{qId}");
                    return RedirectToAction("Index", "QuestionChoices", new { area = "Admin" });
                }
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/tra-loi/hien-thi-theo-cau-hoi/{id}")]
        public async Task<IActionResult> DisplayByQuestion(Guid id)
        {
            try
            {
                var choices = context.QuestionChoices.Include(q => q.Question).Where(x => x.QuestionId == id);
                ViewBag.Count = await choices.CountAsync();
                return View(await choices.ToListAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportQuestions(IFormFile file)
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
                        int i = 1;
                        while (reader.Read())
                        {
                            var className = reader.GetValue(0).ToString();
                            var courseName = reader.GetValue(1).ToString();
                            var testName = reader.GetValue(2).ToString();
                            var questionTitle = reader.GetValue(3).ToString();
                            string[][] answerAndQuestion = { 
                                reader.GetValue(4).ToString().Split(";"), 
                                reader.GetValue(5).ToString().Split(";"),
                                reader.GetValue(6).ToString().Split(";"), 
                                reader.GetValue(7).ToString().Split(";") 
                            };

                            var classExist = await context.Classes
                                .Where(x => x.ClassName.Trim().ToLower() == className.Trim().ToLower())
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

                            var courseExist = await context.Courses
                                .Where(x => x.CourseName.Trim().ToLower() == courseName.Trim().ToLower())
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

                            var testExist = await context.Tests
                                .Where(x => x.TestName.Trim().ToLower() == testName.Trim().ToLower())
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

                            var questionExist = await context.Questions
                                .Where(x => x.QuestionTitle.Trim().ToLower() == questionTitle.Trim().ToLower())
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

                            if (classExist == null || courseExist == null)
                            {
                                NotyfService.Error($"Lỗi tại dòng {i} : lớp hoặc môn học không tồn tại");
                                return RedirectToAction("Index", "QuestionChoices", new { area = "Admin" });
                            }


                            if (testExist == null)
                            {
                                var t = new Test
                                {
                                    TestId = Guid.NewGuid(),
                                    TestName = testName,
                                    IsActive = false,
                                    HasConstructed = false,
                                    CourseId = courseExist.CourseId
                                };
                                context.Tests.Add(t);
                                await context.SaveChangesAsync();
                            }

                            if (questionExist == null)
                            {
                                var q = new Question
                                {
                                    QuestionId = Guid.NewGuid(),
                                    QuestionTitle = questionTitle,
                                    TestId = await context.Tests
                                    .Where(x => x.TestName.Trim().ToLower() == testName.Trim().ToLower())
                                    .AsNoTracking()
                                    .Select(x => x.TestId)
                                    .FirstOrDefaultAsync()
                                };

                                context.Questions.Add(q);
                                await context.SaveChangesAsync();
                            }

                            List<QuestionChoice> qc = new List<QuestionChoice>();
                            foreach(var item in answerAndQuestion)
                            {
                                var choice = await context.QuestionChoices
                                    .Where(x => x.Choice.ToLower().Trim() == item[0].Trim().ToLower())
                                    .FirstOrDefaultAsync();

                                if (choice == null)
                                {
                                    qc.Add(new QuestionChoice
                                    {
                                        ChoiceId = Guid.NewGuid(),
                                        Choice = item[0],
                                        IsRight = item[1]
                                        .ToString().Trim().ToLower() == "đúng" ? true : false,
                                        QuestionId = await context.Questions
                                        .Where(x => x.QuestionTitle.Trim().ToLower() == questionTitle.Trim().ToLower())
                                        .AsNoTracking()
                                        .Select(x => x.QuestionId)
                                        .FirstOrDefaultAsync()
                                    });
                                }
                            }
                            context.QuestionChoices.AddRange(qc);
                            await context.SaveChangesAsync();
                            i++;
                        }
                    }
                }
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                NotyfService.Success("Import thành công");
                return RedirectToAction("Index", "QuestionChoices", new { area = "Admin" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
