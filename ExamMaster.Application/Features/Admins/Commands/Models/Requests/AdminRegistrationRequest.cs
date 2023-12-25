using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Authentications.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Admins.Commands.Models.Requests
{
    public class AdminRegistrationRequest : IRequest<Response<TokenModelResponse>>
    {


        [Required, MaxLength(100)]
        public string Username { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }



    }
}
