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
        public int SubjectId { get; private set; }
        public int? LevelId { get; private set; }
        public ExamGetAllRequest(int subjectId, int? levelId)
        {
            SubjectId = subjectId;
            LevelId = levelId;
        }
    }
}
