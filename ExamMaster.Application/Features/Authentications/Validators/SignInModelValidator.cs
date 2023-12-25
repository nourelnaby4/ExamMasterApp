using ExamMaster.Application.Features.Authentications.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Validators
{
    public class SignInModelValidator : AbstractValidator<SignInRequest>
    {
        public SignInModelValidator()
        {
            ApplyValidator();
        }
        public void ApplyValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(40)
                .MinimumLength(3);

            RuleFor(x => x.Password)
               .NotEmpty()
               .NotNull()
               .MaximumLength(40)
               .MinimumLength(6);
        }
    }
}
