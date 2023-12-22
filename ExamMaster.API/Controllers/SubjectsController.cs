using Azure.Core;
using ExamMaster.API.Base;
using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
using ExamMaster.Application.Features.Subjects.Queries.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root+ "/subject")]
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

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new SubjectGetAllRequest());
            return GetResponse(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var result = await _mediator.Send(new SubjectGetByIdRequest(id));
            return GetResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectCreateRequest request)
        {
            var result= await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] SubjectEditRequest request )
        {
            if (request.Id != id) throw new ValidationException() ;
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var result = await _mediator.Send(new  SubjectDeleteRequest(id));
            return GetResponse(result);
        }
        #endregion

    }
}
