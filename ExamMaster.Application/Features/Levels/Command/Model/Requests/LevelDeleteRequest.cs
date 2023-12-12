using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Command.Model.Requests
{
    public class LevelDeleteRequest : IRequest<Response<string>>
    {
        public int Id { get; private set; }
        public LevelDeleteRequest(int id)
        {
            Id = id;

        }
    }
}
