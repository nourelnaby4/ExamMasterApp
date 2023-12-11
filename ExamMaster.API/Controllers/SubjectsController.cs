using ExamMaster.API.Base;
using ExamMaster.Application.Features.Subjects.Command.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerMain
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region actions
        [HttpPost]
        public async Task<IActionResult> create(SubjectCreateRequest request)
        {
            var result= await _mediator.Send(request);
            return GetResponse(result);
        }
        #endregion

    }
}
