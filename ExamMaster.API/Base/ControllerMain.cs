using AVMS.Application.Common.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;

namespace ExamMaster.API.Base
{

    public class ControllerMain : ControllerBase
    {
        public ObjectResult GetResponse<T>(Response<T> response) =>
           response.StatusCode switch
           {
               HttpStatusCode.OK => new OkObjectResult(response),
               HttpStatusCode.Created => new CreatedResult(string.Empty, response),
               HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
               HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
               HttpStatusCode.NotFound => new NotFoundObjectResult(response),
               HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
               HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
               _ => new BadRequestObjectResult(response)
           };
    }
}
