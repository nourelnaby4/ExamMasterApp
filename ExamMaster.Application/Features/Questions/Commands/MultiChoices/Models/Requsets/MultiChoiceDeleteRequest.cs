using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.Commands.MultiChoices.Models.Requsets
{
    public class MultiChoiceDeleteRequest : IRequest<Response<string>>
    {
        public int QuestionId { get; set; }
        public MultiChoiceDeleteRequest(int questionId)
        { 
            QuestionId = questionId; 
        }
    }
}
