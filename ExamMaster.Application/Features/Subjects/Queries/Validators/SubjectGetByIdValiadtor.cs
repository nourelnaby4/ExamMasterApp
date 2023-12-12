using ExamMaster.Application.Features.Subjects.Queries.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Queries.Validators
{
    public class SubjectGetByIdValiadtor : AbstractValidator<SubjectGetByIdRequest>
    {
        public SubjectGetByIdValiadtor()
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
