using Azure.Core;
using ExamMaster.API.Base;
using ExamMaster.Application.Features.Levels.Command.Model.Requests;
using ExamMaster.Application.Features.Levels.Queries.Models.Requests;
using ExamMaster.Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExamMaster.API.Controllers
{
    [Route(Routing.root + "/level")]
    [Authorize]
    [ApiController]
    public class LevelsController : ControllerMain
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion


        #region constructors
        public LevelsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region actions
      

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new LevelGetAllRequest());
            return GetResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {

            var result = await _mediator.Send(new LevelGetByIdRequest(id));
            return GetResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LevelCreateRequest request)
        {
            var result= await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update( [FromRoute] int id,[FromBody] LevelEditRequest request )
        {
            if (request.Id != id) throw new ValidationException() ;
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var result = await _mediator.Send(new  LevelDeleteRequest(id));
            return GetResponse(result);
        }
        #endregion

    }
}
