using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Models.ViewModels
{
    public class ExamSubmitAnswerViewModel
    {
        public int ExamId { get; set; }
        public QuestionType QuestionType { get; set; }

    }
    public class QuestionType
    {
        public List<ChoiceQuestion> ChoiceQuestions { get; set; }
        //:TODO  public List<ChoiceQuestion>? CompleteQuestion { get; set; }
    }
    public class ChoiceQuestion
    {
        public ChoiceAnswerViewModel Answers { get; set; }

    }
}
