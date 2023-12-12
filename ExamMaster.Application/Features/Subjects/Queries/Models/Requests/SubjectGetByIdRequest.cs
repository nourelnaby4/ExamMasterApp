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
    public class SubjectGetByIdRequest : IRequest<Response<SubjectGetResponse>>
    {
        public int Id { get; private set; }
        public SubjectGetByIdRequest(int id)
        {
            Id = id;

        }
    }
}
