using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Model.Requests
{
    public class SubjectEditRequest : IRequest<Response<string>>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int TotalPoint { get; private set; }
        public SubjectEditRequest(int id, string name, int totalPoint)
        {
            Id = id;
            Name = name;
            TotalPoint = totalPoint;

        }
    }
}
