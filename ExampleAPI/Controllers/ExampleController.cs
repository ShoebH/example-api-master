using ExampleApplication.Requests.Commands;
using ExampleApplication.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExampleAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExampleGet(string exampleValue)
        {
            var result = await _mediator.Send(new ExampleQuery { Value = exampleValue });
            if (result.HasErrors)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExamplePost([FromQuery] string exampleValue)
        {
            var result = await _mediator.Send(new ExampleCommand { Value = exampleValue });
            if (result.HasErrors)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
