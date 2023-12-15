using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Requests
{
    public class ExamGetByIdRequest : IRequest<Response<ExamGetResponse>>
    {
        public int Id { get; private set; }
        public ExamGetByIdRequest(int id) { Id = id; }
    }
}
