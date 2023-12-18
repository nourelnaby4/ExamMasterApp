using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets
{
    public class MultiChoiceEditRequest : IRequest<Response<string>>
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int Point { get; set; } = 5;
        public List<ChoiceViewModel> Answers { get; set; }

    }
}
