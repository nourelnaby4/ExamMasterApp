using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoices.Commands.Models.ViewModel
{
    public class ChoiceViewModel
    {
        public string Content { get; set; }
        public bool IsCorrector { get; set; } = false;


    }
}
