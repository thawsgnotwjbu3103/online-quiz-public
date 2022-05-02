using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public partial class UserAnswer
    {
        [Key]
        public Guid uaId { get; set; }

        [ForeignKey("Student")]
        public Guid StudentId { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionChoice")]
        public Guid ChoiceId { get; set; }

        public bool IsRight { get; set; }

        public virtual Student Student { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionChoice QuestionChoice { get; set; }
    }
}
