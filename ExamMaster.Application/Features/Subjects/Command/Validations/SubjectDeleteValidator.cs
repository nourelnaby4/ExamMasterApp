using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Validations
{
    public class SubjectDeleteValidator : AbstractValidator<SubjectDeleteRequest>
    {
        public SubjectDeleteValidator()
        {
            ApplyValidationsRule();
        }

        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Id)
                .NotNull();
        }
    }
}
