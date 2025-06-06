using AnnouncementService.BLL.Users.Commands;
using AnnouncementService.BLL.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            string token = await _mediator.Send(query);
            return Ok(new { token });
        }
    }
}
