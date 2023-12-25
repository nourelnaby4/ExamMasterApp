using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Application.Features.Exams.Commands.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Validator
{
    public class StudentExamAnswerValidator : AbstractValidator<ExamSubmitAnswerViewModel>
    {
        private readonly IExamRepo _repo;
        public StudentExamAnswerValidator(IExamRepo repo)
        {
            _repo = repo;
            ApplyValidation();
        }

        private void ApplyValidation()
        {
            
            RuleFor(x => x.ExamId)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (key, CancellationToken) => await _repo.IsExistAsync(x => x.Id == key))
                .WithMessage("Exam Id is not exist");

            RuleFor(x => x.QuestionType)
                .NotNull()
                .NotEmpty();


            RuleFor(x => x.QuestionType.ChoiceQuestions)
              .NotNull()
              .NotEmpty();

        }
    }
}
