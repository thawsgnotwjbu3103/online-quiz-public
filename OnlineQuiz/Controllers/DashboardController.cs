using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Infrastructures;
using OnlineQuiz.Models;
using OnlineQuiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Controllers
{
    [Authorize(Roles ="Student")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly QuizDbContext context;
        public DashboardController(UserManager<AppUser> userManager, QuizDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        [Route("/dashboard")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var classId = await context.Users
               .Include(s => s.Student)
               .ThenInclude(c => c.Class)
               .AsNoTracking()
               .Where(x => x.Id == currentUser.Id)
               .Select(x=>x.Student.ClassId)
               .FirstOrDefaultAsync();

            var course = await context.Courses
                .Include(c => c.Class)
                .Where(x => x.ClassId == classId)
                .AsNoTracking()
                .ToListAsync();

            var test = await context.Tests
                .Include(c => c.Course)
                .Where(x=>x.IsActive == true)
                .AsNoTracking()
                .ToListAsync();

            var ctVM = new CourseTestVM()
            {
                Courses = course,
                Tests = test
            };

            return View(ctVM);
        }


        [Route("/vao-thi/{id}")]
        public async Task<IActionResult>TakeExam(Guid id, Guid Cid) 
        {
            try
            {
                var user = await userManager.GetUserAsync(User);

                var point = await context.Points
                    .Include(s => s.Student)
                    .Include(c => c.Course)
                    .Include(t => t.Test)
                    .Where(x => x.StudentId == user.StudentId && x.TestId == id && x.CourseId == Cid)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (point != null) return NotFound();

                var test = await context.Tests.FindAsync(id);
                ViewBag.testName = test.TestName.ToUpper();

                if (test == null) return NotFound();

                var question = await context.Questions
                    .Include(t => t.Test)
                    .Where(x => x.TestId == test.TestId)
                    .AsNoTracking()
                    .OrderBy(x => Guid.NewGuid())
                    .ToListAsync();

                var answer = await context.QuestionChoices
                    .Include(q => q.Question)
                    .AsNoTracking()
                    .OrderBy(x=> Guid.NewGuid())
                    .ToArrayAsync();

                TempData["TestId"] = test.TestId;
                TempData["CourseId"] = test.CourseId;
                TempData.Keep();

                var qaVM = new QuestionAnswerVM()
                {
                    Questions = question,
                    Choices = answer
                };
                return View(qaVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/nop-bai")]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SubmitExam(List<string> answers)
        {
            List<UserAnswer> uaList = new List<UserAnswer>();
            var user = await userManager.GetUserAsync(User);
            foreach (var item in answers)
            {
                var choice = await context.QuestionChoices.FindAsync(new Guid(item));
                var check = await context.UserAnswers
                    .Where(x=>x.StudentId == user.StudentId && x.ChoiceId == choice.ChoiceId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if(check == null)
                {
                    UserAnswer ua = new UserAnswer
                    {
                        uaId = Guid.NewGuid(),
                        ChoiceId = choice.ChoiceId,
                        QuestionId = choice.QuestionId,
                        StudentId = (Guid)user.StudentId,
                        IsRight = choice.IsRight
                    };
                    uaList.Add(ua);
                }
            }

            context.UserAnswers.AddRange(uaList);
            await context.SaveChangesAsync();

            var totalRight = await context.UserAnswers
                .AsNoTracking()
                .Where(x => x.Question.TestId == new Guid(TempData["TestId"].ToString()) 
                && x.IsRight == true 
                && x.StudentId == user.StudentId)
                .CountAsync();
            
            var totalQuestion = context.Questions.Count();

            double totalPoint = ((double)totalRight / (double)totalQuestion) * 10;

            context.Points.Add(new Point
            {
                PointId = Guid.NewGuid(),
                AnswerTime = DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy"),
                TestId = new Guid(TempData["TestId"].ToString()),
                CourseId = new Guid(TempData["CourseId"].ToString()),
                StudentId = (Guid)user.StudentId,
                TotalPoint = (int)totalPoint,
            });

            await context.SaveChangesAsync();
            return Redirect("/dashboard");
        }

        [Route("/ket-qua")]
        public async Task<IActionResult> PointIndex()
        {
            var user = await userManager.GetUserAsync(User);
            var result = await context.Points
                .Include(x => x.Student)
                .Include(x => x.Test)
                .Include(x => x.Course)
                .AsNoTracking()
                .Where(x => x.StudentId == (Guid)user.StudentId)
                .ToListAsync();
            return View(result);
        }
    }
}
