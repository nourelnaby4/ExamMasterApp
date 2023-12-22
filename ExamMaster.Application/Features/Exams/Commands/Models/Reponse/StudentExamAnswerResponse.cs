using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Models.Reponse
{
    public class StudentExamAnswerResponse
    {
        public int ExamId { get; set; }

        public int TotalPoint { get; set; }

        public bool IsSuccess { get; set; } 

     
    }


}
