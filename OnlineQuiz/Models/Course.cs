using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [ForeignKey("Class")]
        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
