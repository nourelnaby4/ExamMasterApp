using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser() {
            StudentExams = new HashSet<StudentExam>();
        }

        [InverseProperty(nameof(StudentExam.Student))]
        public virtual ICollection<StudentExam> StudentExams { get; set; }

    }
}
