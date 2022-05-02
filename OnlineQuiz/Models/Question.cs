using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }

        public string QuestionTitle { get; set; }

        [ForeignKey("Test")]
        public Guid TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
