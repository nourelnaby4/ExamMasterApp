using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Subject
    {
        public Subject() {
            Exams = new HashSet<Exam>();
            SubjectLevels = new HashSet<SubjectLevel>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public int TotalPoint { get; set; } = 0;


        [InverseProperty(nameof(Exam.Subject))]
        public virtual ICollection<Exam> Exams { get; set; }

        [InverseProperty(nameof(SubjectLevel.Subject))]
        public virtual ICollection<SubjectLevel> SubjectLevels { get; set;}
    }
}
