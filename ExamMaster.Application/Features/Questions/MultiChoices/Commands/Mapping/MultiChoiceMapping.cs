using AutoMapper;
using ExamMaster.Application.Common.Consts;
using ExamMaster.Application.Features.Questions.MultiChoices.Commands.Models.Requsets;
using ExamMaster.Application.Features.Questions.MultiChoices.Commands.Models.ViewModel;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoices.Commands.Mapping
{
    public class MultiChoiceMapping : Profile
    {
        public MultiChoiceMapping()
        {
            CreateMultiChoices();
            // CreateChoices();
        }

        private void CreateMultiChoices()
        {
            CreateMap<MultiChoiceCreateRequest, Question>()
                .ForMember(dest => dest.Content, option => option.MapFrom(src => src.Question))
                .ForMember(dest => dest.QuestionTypeId, option => option.MapFrom(src => QuestionTypeEnum.Choices))
                .ForMember(dest => dest.Choices, option => option.MapFrom(src => ConvertToChoice(src.Answers)));
        }

        private IEnumerable<Choice> ConvertToChoice(List<ChoiceViewModel> choicesModel)
        {
            foreach (var item in choicesModel)
            {
                yield return new Choice
                {
                    Content = item.Content,
                    IsCorrect = item.IsCorrector,


                };
            }
        }
    }
}
