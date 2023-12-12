using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Model.Requests
{
    public class SubjectCreateRequest : IRequest<Response<string>>
    {
        public string Name { get; private set; }
        public int TotalPoint { get; private set; }
        public SubjectCreateRequest(string name, int totalPoint)
        {
            Name = name;
            TotalPoint = totalPoint;

        }
    }
}
