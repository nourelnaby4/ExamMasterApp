using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response
{
    public class QuestionGroupResponse
    {
        public QuestionGroupResponse() {
            Questions=new HashSet<Question>();
        }
        public string QuestionTypeName { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
