using AutoMapper;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Mapping
{
    public class ExamQueryMapping : Profile
    {
        public ExamQueryMapping()
        {
            GetExam();
        }

        public void GetExam()
        {
            CreateMap<Exam, ExamGetAllResponse>()
                .ForMember(dest => dest.LevelName, options => options.MapFrom(src => src.Level.Name))
                .ForMember(dest => dest.SubjectName, options => options.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.ExamId, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.ExamTitle, options => options.MapFrom(src => src.Title));
        }
    }
}
