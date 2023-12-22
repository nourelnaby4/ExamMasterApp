using ExamMaster.API.Base;
using ExamMaster.Application.Features.Exams.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerMain
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public StudentsController(IMediator mediator) {
            _mediator = mediator;
        }
        #endregion


        #region endpoints
      
        #endregion

    }
}
