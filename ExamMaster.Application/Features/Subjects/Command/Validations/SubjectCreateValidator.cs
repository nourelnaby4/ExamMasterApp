﻿using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
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
                .NotEmpty().NotNull().Length(3, 30);

            RuleFor(x => x.TotalPoint)
                .NotNull();
        }
    }
}
