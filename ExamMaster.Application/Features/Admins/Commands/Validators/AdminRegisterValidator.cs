﻿using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Admins.Commands.Models.Requests;
using ExamMaster.Application.Features.Students.Commands.Models.Requests;
using ExamMaster.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Admins.Commands.Validators
{
    public class AdminRegisterValidator : AbstractValidator<AdminRegistrationRequest>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminRegisterValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            ApplyValidations();
        }
        public void ApplyValidations()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(40)
            .MinimumLength(3)
                .MustAsync(async (key, CancellationToken) => await _userManager.FindByNameAsync(key) == null).WithMessage("username is already used");


            RuleFor(x => x.Email)
               .NotEmpty()
               .NotNull()
            .EmailAddress()
               .MustAsync(async (key, CancellationToken) => await _userManager.FindByEmailAsync(key) == null).WithMessage("email is already used"); ;

            RuleFor(x => x.Password)
               .NotEmpty()
               .NotNull()
               .MaximumLength(40)
               .MinimumLength(6);
        }
    }
}
