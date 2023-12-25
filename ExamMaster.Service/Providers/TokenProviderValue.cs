using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Service.Providers
{
    public class TokenProviderValue
    {
        public object? Value { get; set; }
        public DateTime ExpirDate { get; set; } = DateTime.Now.AddMinutes(10);
        public bool IsValid => ExpirDate  > DateTime.UtcNow;
    }
}
