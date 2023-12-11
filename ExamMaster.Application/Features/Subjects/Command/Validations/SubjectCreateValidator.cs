using ExamMaster.Application.Features.Subjects.Command.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Validations
{
    public class SubjectCreateValidator : AbstractValidator<SubjectCreateRequest>
    {
        public SubjectCreateValidator() 
        {
            ApplyValidationsRule();
        }

        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty().NotNull().MaximumLength(20).MinimumLength(3);

            RuleFor(x => x.TotalPoint)
                .NotNull();
        }
    }
}
