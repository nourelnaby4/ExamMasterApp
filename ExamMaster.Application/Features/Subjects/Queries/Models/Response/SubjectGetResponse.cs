using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Queries.Models.Response
{
    public class SubjectGetResponse 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int TotalPoint { get; private set; }
        public SubjectGetResponse(int id, string name, int totalPoint)
        {
            Id = id;
            Name = name;
            TotalPoint = totalPoint;

        }
    }
}
