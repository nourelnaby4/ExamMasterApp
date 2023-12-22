using AutoMapper;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Mapping
{
    public class MultiChoiceMapping : Profile
    {
        public MultiChoiceMapping()
        {
            CreateMultiChoices();
            EditMultiChoices();
        }

        private void CreateMultiChoices()
        {
            CreateMap<MultiChoiceCreateRequest, Question>()
                .ForMember(dest => dest.Content, option => option.MapFrom(src => src.Question))
                .ForMember(dest => dest.QuestionTypeId, option => option.MapFrom(src => QuestionTypeEnum.Choices))
                .ForMember(dest => dest.Choices, option => option.MapFrom(src => ConvertToChoice(src.Answers)));
        }
        private void EditMultiChoices()
        {
            CreateMap<MultiChoiceEditRequest, Question>()
                .ForMember(dest => dest.Id, option => option.MapFrom(src => src.QuestionId))
                .ForMember(dest => dest.Content, option => option.MapFrom(src => src.Question))
                .ForMember(dest => dest.QuestionTypeId, option => option.MapFrom(src => QuestionTypeEnum.Choices))
                .ForMember(dest => dest.Choices, option => option.MapFrom(src => ConvertToChoice(src.Answers)));
        }

        private IEnumerable<Choice> ConvertToChoice(List<ChoiceCreateViewModel> choicesModel)
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
