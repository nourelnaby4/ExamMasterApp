using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel
{
    public class ChoiceCreateViewModel
    {
        public string Content { get; set; }
        public bool IsCorrector { get; set; } = false;


    }
}
