using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public partial class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public bool Gender { get; set; }

        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey("Class")]
        public Guid ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
