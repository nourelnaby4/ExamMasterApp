﻿using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Validator
{
    public class ExamEditValidator : AbstractValidator<ExamEditRequest>
    {
        private readonly IUnitOfWork _repo;
        public ExamEditValidator(IUnitOfWork repo) {
            _repo = repo;

            ApplyExamValidator();
            ApplyCustomValidator();
        }

        private void ApplyExamValidator()
        {
           

            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.ExamSuccessRate)
                .NotNull()
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(30);
        }

        private void ApplyCustomValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .MustAsync(async (key, CancellationToken) => await _repo.Exam.IsExistAsync(x => x.Id == key)).WithMessage("Exam Id Not Exist");


            RuleFor(x => x.LevelId)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (key, CancellationToken) => await _repo.Level.IsExistAsync(x => x.Id == key)).WithMessage("Level Id Not Exist");


            RuleFor(x => x.SubjectId)
               .NotNull()
               .NotEmpty()
               .MustAsync(async (key, CancellationToken) => await _repo.Subject.IsExistAsync(x => x.Id == key)).WithMessage("Subject Id Not Exist");
        }
    }
}
