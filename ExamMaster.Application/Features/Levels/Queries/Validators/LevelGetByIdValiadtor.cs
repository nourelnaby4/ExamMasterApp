using ExamMaster.Application.Features.Levels.Queries.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Queries.Validators
{
    public class LevelGetByIdValiadtor : AbstractValidator<LevelGetByIdRequest>
    {
        public LevelGetByIdValiadtor()
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
