using ExamMaster.Application.Features.Levels.Command.Model.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Command.Validations
{
    public class LevelEditValidator :AbstractValidator<LevelEditRequest>
    {
        public LevelEditValidator()
        {
            ApplyValidationsRule();
        }

        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Id)
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty().NotNull().Length(3, 30);
        }
    }
}
