using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
            StudentExams = new HashSet<StudentExam>();
           
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }

        [Range(0, 100, ErrorMessage = "Exam Success Rate must be between 0 and 100")]
        public decimal ExamSuccessRate { get; set; }


        public virtual int LevelId { get; set; }
        public virtual int SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.Exams))]
        public virtual Subject Subject { get; set; }


   

        [ForeignKey(nameof(LevelId))]
        [InverseProperty(nameof(Level.Exams))]
        public virtual Level Level { get; set; }

        [InverseProperty(nameof(Question.Exam))]
        public virtual ICollection<Question> Questions { get; set; }

        [InverseProperty(nameof(StudentExam.Exam))]
        public virtual ICollection<StudentExam> StudentExams { get; set; }


    }
}
