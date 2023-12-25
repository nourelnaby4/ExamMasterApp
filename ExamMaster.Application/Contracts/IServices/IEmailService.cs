using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);


    }
}
