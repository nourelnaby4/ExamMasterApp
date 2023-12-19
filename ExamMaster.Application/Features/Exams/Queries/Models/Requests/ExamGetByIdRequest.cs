using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using MediatR;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Requests
{
    public class ExamGetByIdRequest : IRequest<Response<ExamGetAllResponse>>
    {
        public int Id { get; set; }
    }
}
