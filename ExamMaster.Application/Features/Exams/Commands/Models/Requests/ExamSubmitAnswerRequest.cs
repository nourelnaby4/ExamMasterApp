using AVMS.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Commands.Models.Reponse;
using ExamMaster.Application.Features.Exams.Commands.Models.ViewModels;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Models.Requests
{
    public class ExamSubmitAnswerRequest : IRequest<Response<ExamSubmitAnswerResponse>>
    {
        public ClaimsPrincipal UserClaims { get; set; }
        public ExamSubmitAnswerViewModel ViewModel { get; set; }
        public ExamSubmitAnswerRequest(ClaimsPrincipal userClaims, ExamSubmitAnswerViewModel viewModel)
        {
            UserClaims = userClaims;
            ViewModel = viewModel;
        }
    }
}
