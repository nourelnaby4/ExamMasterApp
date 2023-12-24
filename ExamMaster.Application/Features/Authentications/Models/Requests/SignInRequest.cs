﻿using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Authentications.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Models.Requests
{

    public class SignInRequest : IRequest<Response<TokenModelResponse>>
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
