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

        public int Score { get; set; } = 0;
        public decimal ScoreRate { get; set; }
        public bool IsSuccess { get; set; } = false;

        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(ApplicationUser.StudentExams))]
        public virtual ApplicationUser Student { get; set; }

        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Exam.StudentExams))]
        public virtual Exam Exam { get; set; }
    }
}
