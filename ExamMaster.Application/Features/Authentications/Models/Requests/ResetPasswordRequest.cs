using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Models.Requests
{
    public class ResetPasswordRequest : IRequest<Response<string>>
    {
        [MaxLength(6)]
        public string ResetCode { get;private set; }


        [EmailAddress]
        public string Email { get;private set; }

       

        [MaxLength(10)]
        public string NewPassword { get;private set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; private set; }


        public ResetPasswordRequest(string resetCode,string email,string newPassword,string confirmPassword) 
        {
            this.ResetCode = resetCode;
            this.Email = email;
            this.NewPassword = newPassword;
            this.ConfirmPassword = confirmPassword;
        }

    }
}
