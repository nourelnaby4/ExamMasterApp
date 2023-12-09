using ExamMaster.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public Answer CorrectAnswer { get; set; }
    }
}
