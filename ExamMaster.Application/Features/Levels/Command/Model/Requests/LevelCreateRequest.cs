using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Command.Model.Requests
{
    public class LevelCreateRequest : IRequest<Response<string>>
    {
        public string Name { get; private set; }
        public LevelCreateRequest(string name)
        {
            Name = name;

        }
    }
}
