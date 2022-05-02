using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }

        [Required]
        public string TestName { get; set; }

        public bool IsActive { get; set; }

        public bool HasConstructed { get; set; }
 
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        
        public virtual Course Course { get; set; }
    }
}
