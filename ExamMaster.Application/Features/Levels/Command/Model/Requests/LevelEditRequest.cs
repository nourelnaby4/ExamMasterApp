using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Command.Model.Requests
{
    public class LevelEditRequest : IRequest<Response<string>>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public LevelEditRequest(int id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
