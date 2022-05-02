using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.ViewModels
{
    public class QuestionAnswerVM
    {
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<QuestionChoice> Choices { get; set; }
    }
}
