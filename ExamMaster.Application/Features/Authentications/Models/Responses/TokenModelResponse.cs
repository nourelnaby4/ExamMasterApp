using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Authentications.Models.Responses
{
    public class TokenModelResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }

}
