using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty(nameof(Question.Answers))]
        public Question Question { get; set; }



    }
}
