using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Requests
{
    public class QuestionGetRequest : IRequest<Response<PaginatedResult<QuestionGetResponse>>>
    {
        public int ExamId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
