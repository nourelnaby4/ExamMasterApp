using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public int Point { get; set; } = 5;
        public int CorrectAnswerId {  get; set; }

        public int ExamId { get;set; }




        [InverseProperty(nameof(Answer.Question))]
        public ICollection<Answer> Answers { get; set; }

        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Exam.Questions))]
        public virtual Exam? Exam { get; set; }


    }
}
