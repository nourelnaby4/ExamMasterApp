using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Levels.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Queries.Models.Requests
{
    public class LevelGetAllRequest : IRequest<Response<IEnumerable<LevelGetResponse>>>
    {
        public LevelGetAllRequest() { }
    }
}
