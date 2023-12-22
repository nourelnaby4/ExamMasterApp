using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Services
{
    public class StudentExamFactory : IStudentExamFactory
    {
        public StudentExam CreateStudentExam(string studentId, int examId, int totalPoint,decimal scoreRate,  bool isSuccess)
        {
            // Additional logic or validation can be added here before creating the object
            return new StudentExam
            {
                StudentId = studentId,
                ExamId = examId,
                Score = totalPoint,
                ScoreRate = scoreRate,
                IsSuccess = isSuccess
            };
        }
    }
}
