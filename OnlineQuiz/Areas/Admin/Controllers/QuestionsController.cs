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
    public class QuestionsController : Controller
    {
        private readonly QuizDbContext context;
        public INotyfService NotyfService { get; }

        public QuestionsController(QuizDbContext context, INotyfService NotyfService)
        {
            this.context = context;
            this.NotyfService = NotyfService;
        }

        [Route("/admin/cau-hoi")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var questions = context.Questions.Include(t => t.Test);
                ViewBag.Count = await questions.CountAsync();
                return View(await questions.ToListAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/cau-hoi/tao-moi")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Test = new SelectList(context.Tests,"TestId", "TestName");
            return View();
        }

        [Route("/admin/cau-hoi/tao-moi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    question.QuestionId = Guid.NewGuid();
                    context.Add(question);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Tạo thành công");
                    return RedirectToAction("Index", "Questions", new { area = "Admin" });
                }
                return View(question);
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [Route("/admin/cau-hoi/chinh-sua/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                ViewBag.Test = new SelectList(context.Tests, "TestId", "TestName");
                var questions = await context.Questions.FindAsync(id);
                if (questions != null) return View(questions);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/cau-hoi/chinh-sua/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Question question)
        {
            ViewBag.Test = new SelectList(context.Tests, "TestId", "TestName");
            try
            {
                if (ModelState.IsValid)
                {
                    question.QuestionId = id;
                    context.Update(question);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Sửa thành công");
                    return RedirectToAction("Index", "Questions", new { area = "Admin" });
                }
                return View(question);
            }
            catch (Exception ex)
            {
                NotyfService.Error($"Lỗi: {ex.Message}");
                throw;
            }
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid id, Guid? Tid)
        {
            try
            {
                var exist = await context.Questions.FindAsync(id);
                if(exist != null)
                {
                    context.Remove(exist);
                    await context.SaveChangesAsync();
                    NotyfService.Success("Xóa thành công");
                    if (Tid != null) return Redirect($"/admin/cau-hoi/hien-thi-theo-bai-thi/{Tid}");
                    return RedirectToAction("Index", "Questions", new { area = "Admin"});
                }
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/admin/cau-hoi/hien-thi-theo-bai-thi/{id}")]
        public async Task<IActionResult> DisplayByTest(Guid id)
        {
            try
            {
                var questions = context.Questions.Include(t => t.Test).Where(x=>x.TestId == id);
                ViewBag.Count = await questions.CountAsync();
                return View(await questions.ToListAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
