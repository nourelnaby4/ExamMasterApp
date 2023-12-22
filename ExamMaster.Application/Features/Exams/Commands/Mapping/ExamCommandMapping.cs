using AutoMapper;
using ExamMaster.Application.Features.Exams.Commands.Models.Reponse;
using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Mapping
{
    public class ExamCommandMapping : Profile
    {
        public ExamCommandMapping()
        {
            CreateExam();
            EditExam();
            CreateStudentExamAnswerResponse();
        }

        private void CreateExam()
        {
            CreateMap<ExamCreateRequest, Exam>();
        }

        private void EditExam()
        {
            CreateMap<ExamEditRequest, Exam>();
        }

        private void CreateStudentExamAnswerResponse()
        {
            CreateMap<StudentExam,StudentExamAnswerResponse>().ReverseMap();
        }
    }
}
