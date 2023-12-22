using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel
{
    public class QuestionsChoiceCorrectAnswer
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int QuestionPoint {  get; set; }
    }
}
