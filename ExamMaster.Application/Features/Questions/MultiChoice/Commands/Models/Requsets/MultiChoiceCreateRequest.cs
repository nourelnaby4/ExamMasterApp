using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets
{
    public class MultiChoiceCreateRequest : IRequest<Response<string>>
    {
        public string Question { get; private set; }
        public int ExamId { get; private set; }
        public int Point { get; private set; } = 5;
        public List<ChoiceViewModel> Answers { get; set; }





        public MultiChoiceCreateRequest(string question, List<ChoiceViewModel> answers, int examId, int point)
        {
            Question = question;
            Answers = answers;
            Point = point;
            ExamId = examId;
        }
    }
}
