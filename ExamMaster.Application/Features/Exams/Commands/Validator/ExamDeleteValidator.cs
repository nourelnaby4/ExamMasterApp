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
    public class ExamDeleteValidator : AbstractValidator<ExamDeleteRequest>
    {
        private readonly IUnitOfWork _repo;
        public ExamDeleteValidator(IUnitOfWork repo)
        {
            _repo = repo;
            ApplyCustomValidator();
        }
        private void ApplyCustomValidator()
        {
            
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .MustAsync(async (key, CancellationToken) => await _repo.Exam.IsExistAsync(x => x.Id == key)).WithMessage("Exam Id Not Exist");


        }
    }
}
