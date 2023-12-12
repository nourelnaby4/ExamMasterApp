using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Queries.Models.Response
{
    public class LevelGetResponse 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public LevelGetResponse(int id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
