using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models
{
    public class AppUser : IdentityUser
    {
        public string Opccupation { get; set; }

        [ForeignKey("Student")]
        public Guid? StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
