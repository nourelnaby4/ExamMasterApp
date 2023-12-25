using AVMS.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string OldPassword { get; private set; }
        public string NewPassword { get; private set; }
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; private set; }

        public ChangePasswordViewModel(string newPassword, string oldPassword, string confirmPassword)
        {
            NewPassword = newPassword;
            OldPassword = oldPassword;
            ConfirmPassword = confirmPassword;
        }
    }
}
