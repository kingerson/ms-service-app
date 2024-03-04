using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MsServiceApp
{
    public class MatrixController : BaseApiController
    {
        public MatrixController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError),(int)HttpStatusCode.BadRequest,contentType:"application/json")]
        public async Task<IActionResult> Rotate(RotateMatrixCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}