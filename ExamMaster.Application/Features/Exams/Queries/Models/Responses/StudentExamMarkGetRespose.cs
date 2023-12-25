using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Models.Responses
{
    public class StudentExamMarkGetRespose
    {

        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string LevelName { get; set; }
        public string ExamTitle { get; set; }
        public int TotalScore { get; set; }
        public decimal ScoreRate { get; set; }
        public bool IsSuccess { get; set; }


    }
}
