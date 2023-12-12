using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Validations
{
    public class SubjectEditValidator :AbstractValidator<SubjectEditRequest>
    {
        public SubjectEditValidator()
        {
            ApplyValidationsRule();
        }

        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Id)
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty().NotNull().Length(3, 30);

            RuleFor(x => x.TotalPoint)
                .NotNull();
        }
    }
}
