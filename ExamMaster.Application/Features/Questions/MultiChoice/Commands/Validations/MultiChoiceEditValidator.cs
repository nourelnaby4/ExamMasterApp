using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Validations
{
    public class MultiChoiceEditValidator : AbstractValidator<MultiChoiceEditRequest>
    {
        public MultiChoiceEditValidator()
        {
            ApplyEditMultiChoice();
            ApplyCustomEditMultiChoice();

        }
        private void ApplyEditMultiChoice()
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


        private void ApplyCustomEditMultiChoice()
        {
            RuleFor(x => x.Answers)
                .Must((key, CancellationTokenSource) => key.Answers.Count() == 4).WithMessage("choies count must be 4 choise only");


        }
    }
}
