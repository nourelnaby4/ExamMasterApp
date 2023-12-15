using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Features.Questions.MultiChoices.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoices.Queries.Models.Requests
{
    public class MultiChoiceGetRequest : IRequest<PaginatedResult<IEnumerable<MultiChoiceGetResponse>>>
    {
        public int SubjectId { get; private set; }
        public int LevelId { get; private set; }
        public MultiChoiceGetRequest(int subjectId, int levelId)
        {
            subjectId = SubjectId;
            levelId = LevelId;
        }
    }
}
