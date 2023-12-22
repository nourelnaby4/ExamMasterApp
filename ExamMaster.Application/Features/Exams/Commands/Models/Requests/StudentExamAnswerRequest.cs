using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Commands.Models.Reponse;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Models.Requests
{
    public class StudentExamAnswerRequest : IRequest<Response<StudentExamAnswerResponse>>
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
