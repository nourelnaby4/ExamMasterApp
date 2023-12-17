using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.Queries.Models.Response
{
    public class QuestionGetResponse
    {
        public int Id { get; set; }
        public int QuestionTypeId { get; set; }
        public string QuestionTypeName { get; set; }
        public string Content { get; set; }
    }
}
