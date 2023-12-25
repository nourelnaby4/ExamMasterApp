using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Requests
{
    public class StudnetExamMarkeGetRequest : IRequest<Response<PaginatedResult<StudentExamMarkGetRespose>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        public StudnetExamMarkeGetRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
