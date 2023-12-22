using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Requests
{
    public class ExamQuestionGroupingRequest : IRequest<Response<IEnumerable<ExamQuestionGroupResponse>>>
    {
        public int ExamId { get; set; }
    }
}
