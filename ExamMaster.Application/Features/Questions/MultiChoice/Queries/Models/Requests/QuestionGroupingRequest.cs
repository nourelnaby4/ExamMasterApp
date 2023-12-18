using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Requests
{
    public class QuestionGroupingRequest : IRequest<Response<IEnumerable<QuestionGroupResponse>>>
    {
        public int ExamId { get; set; }
    }
}
