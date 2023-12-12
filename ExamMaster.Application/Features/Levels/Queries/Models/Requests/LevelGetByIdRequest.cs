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
    public class LevelGetByIdRequest : IRequest<Response<LevelGetResponse>>
    {
        public int Id { get; private set; }
        public LevelGetByIdRequest(int id)
        {
            Id = id;

        }
    }
}
