using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Models
{
    public class ExamCreateRequest : IRequest<Response<string>>
    {
        public int SubjectId { get; set; }
        public int LevelId { get; set; }
        public decimal ExamSuccessRate { get; set; }

        public string Title { get; set; }
        public ExamCreateRequest(int subjectId, int levelId, string title, decimal examSuccessRate)
        {
            SubjectId = subjectId;
            LevelId = levelId;
            Title = title;
            ExamSuccessRate = examSuccessRate;
        }
    }
}
