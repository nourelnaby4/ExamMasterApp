using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Model.Requests
{
    public class SubjectDeleteRequest : IRequest<Response<string>>
    {
        public int Id { get; private set; }
        public SubjectDeleteRequest(int id)
        {
            Id = id;

        }
    }
}
