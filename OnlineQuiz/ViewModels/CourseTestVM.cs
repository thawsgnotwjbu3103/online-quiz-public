using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.ViewModels
{
    public class CourseTestVM
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}
