using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Responses
{
    public class ExamQuestionGroupResponse
    {
        public ExamQuestionGroupResponse()
        {
            Questions = new HashSet<Question>();
        }
        public string QuestionTypeName { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
