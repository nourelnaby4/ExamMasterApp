using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Subjects.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Queries.Models.Requests
{
    public class SubjectGetAllRequest : IRequest<Response<IEnumerable<SubjectGetResponse>>>
    {
        public SubjectGetAllRequest() { }
    }
}
