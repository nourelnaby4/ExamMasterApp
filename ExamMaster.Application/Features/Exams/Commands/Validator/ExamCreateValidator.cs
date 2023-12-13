using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Exams.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Validator
{
    public class ExamCreateValidator : AbstractValidator<ExamCreateRequest>
    {
        private readonly IUnitOfWork _repo;
        public ExamCreateValidator(IUnitOfWork repo) {
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
            RuleFor(x => x.LevelId)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (key, CancellationToken) => await _repo.Level.IsExistAsync(x => x.Id == key)).WithMessage("Level Id is not Exist");


            RuleFor(x => x.SubjectId)
               .NotNull()
               .NotEmpty()
               .MustAsync(async (key, CancellationToken) => await _repo.Level.IsExistAsync(x => x.Id == key)).WithMessage("Subject Id not Exist");
        }
    }
}
