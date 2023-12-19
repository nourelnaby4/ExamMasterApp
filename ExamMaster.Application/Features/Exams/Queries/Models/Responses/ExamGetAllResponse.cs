using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Responses
{
    public class ExamGetAllResponse
    {
        public int ExamId { get; set; }
        public string SubjectName { get; set; }
        public string LevelName { get; set; }
        public decimal ExamSuccessRate { get; set; }

        public string ExamTitle { get; set; }

    }
}
