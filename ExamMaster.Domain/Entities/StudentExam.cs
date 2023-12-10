using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class StudentExam
    {
        [Key]
        public string StudentId { get; set; }

        [Key]
        public int ExamId { get; set; }

        public int TotalPoint { get; set; } = 0;

        public bool IsSuccess { get; set; } = false;

        [ForeignKey(nameof(StudentId))]
        public virtual ApplicationUser Student { get; set; }

        [ForeignKey(nameof(ExamId))]
        public virtual Exam Exam { get; set; }
    }
}
