using AutoMapper;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Queries.Mapping
{
    public class QuestionGetMapping : Profile
    {
        public QuestionGetMapping()
        {
            GetQuestions();
        }

        private void GetQuestions()
        {
            CreateMap<Question, QuestionGetResponse>()
                .ForMember(dest => dest.QuestionTypeName, option => option.MapFrom(src => src.QuestionType.TypeName));
        }
    }
}
