using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Validations
{
    public class MultiChoiceCreateValidator : AbstractValidator<MultiChoiceCreateRequest>
    {
        private readonly IUnitOfWork _repo;
        public MultiChoiceCreateValidator(IUnitOfWork repo)
        {
            _repo = repo;
            ApplyCreateMultiChoice();
            ApplyCustomCreateMultiChoice();

        }
        private void ApplyCreateMultiChoice()
        {
            RuleFor(x => x.Question)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000)
                .MinimumLength(3);

            RuleFor(x => x.Point)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Answers)
               .NotNull()
               .NotEmpty();



        }

        private void ApplyCustomCreateMultiChoice()
        {
            RuleFor(x => x.ExamId)
            .MustAsync(async (key, CancellationTokenSource) => await _repo.Exam.IsExistAsync(x => x.Id == key)).WithMessage("Exam Id is not Exist");

            RuleFor(x => x.Answers)
                .Must((key, CancellationTokenSource) => key.Answers.Count() == 4).WithMessage("choies count must be 4 choise only");


        }
    }
}
