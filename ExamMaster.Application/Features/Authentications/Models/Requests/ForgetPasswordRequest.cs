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
    public class ForgetPasswordRequest : IRequest<Response<string>>
    {
        [EmailAddress]
        public string email { get; set; }
    }
}
