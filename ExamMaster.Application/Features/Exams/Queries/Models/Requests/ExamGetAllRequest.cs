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
    public class ExamGetAllRequest : IRequest<Response<IEnumerable< ExamGetResponse>>>
    {
        //public int ExamId { get; private set; }
        //public ExamGetAllRequest(int examID) 
        //{
        //    ExamId = examID;
        //}
    }
}
