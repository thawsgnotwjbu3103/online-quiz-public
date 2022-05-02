using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public class QuestionChoice
    {
        [Key]
        public Guid ChoiceId { get; set; }

        public string Choice { get; set; }

        public bool IsRight { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
