using Azure.Core;
using ExamMaster.API.Base;
using ExamMaster.Application.Features.Levels.Command.Model.Requests;
using ExamMaster.Application.Features.Levels.Queries.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExamMaster.API.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("get-byid")]
        public async Task<IActionResult> GetById([FromQuery] int LevelId)
        {

            var result = await _mediator.Send(new LevelGetByIdRequest(LevelId));
            return GetResponse(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new LevelGetAllRequest());
            return GetResponse(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LevelCreateRequest request)
        {
            var result= await _mediator.Send(request);
            return GetResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LevelEditRequest request ,[FromQuery] int LevelId)
        {
            if (request.Id != LevelId) throw new ValidationException() ;
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int LevelId)
        {

            var result = await _mediator.Send(new  LevelDeleteRequest(LevelId));
            return GetResponse(result);
        }
        #endregion

    }
}
