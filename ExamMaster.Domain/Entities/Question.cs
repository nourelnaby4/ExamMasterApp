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
            Choices = new HashSet<Choice>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public int Point { get; set; } = 5;

        public int? ExamId { get;set; }

        public int QuestionTypeId { get; set; }

        [ForeignKey(nameof(QuestionTypeId))]
        [InverseProperty(nameof(QuestionType.Questions))]
        public QuestionType QuestionType { get; set; }

        [InverseProperty(nameof(Choice.Question))]
        public ICollection<Choice>? Choices { get; set; }

        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Exam.Questions))]
        public virtual Exam? Exam { get; set; }


    }
}
