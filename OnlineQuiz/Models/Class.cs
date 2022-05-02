using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public partial class Class
    {
        [Key]
        public Guid ClassId { get; set; }

        [Required]
        public string ClassName { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
