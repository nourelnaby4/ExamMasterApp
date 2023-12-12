using Azure.Core;
using ExamMaster.API.Base;
using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
using ExamMaster.Application.Features.Subjects.Queries.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [HttpGet("get-byid")]
        public async Task<IActionResult> GetById([FromQuery] int subjectId)
        {

            var result = await _mediator.Send(new SubjectGetByIdRequest(subjectId));
            return GetResponse(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new SubjectGetAllRequest());
            return GetResponse(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectCreateRequest request)
        {
            var result= await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SubjectEditRequest request ,[FromQuery] int subjectId)
        {
            if (request.Id != subjectId) throw new ValidationException() ;
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int subjectId)
        {

            var result = await _mediator.Send(new  SubjectDeleteRequest(subjectId));
            return GetResponse(result);
        }
        #endregion

    }
}
