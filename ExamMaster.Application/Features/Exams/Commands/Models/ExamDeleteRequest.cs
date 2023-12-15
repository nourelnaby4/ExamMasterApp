using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Models
{
    public class ExamDeleteRequest : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public ExamDeleteRequest(int id) { Id = id; }
    }
}
