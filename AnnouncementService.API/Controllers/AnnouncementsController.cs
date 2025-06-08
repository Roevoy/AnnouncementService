using AnnouncementService.BLL.Announcements.Queries;
using AnnouncementService.BLL.Queries;
using AnnouncementService.BLL.Сommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnnouncementService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnnouncementsController(IMediator mediator)
        {
#if DEBUG
            Task.Delay(2000).Wait(); 
#endif
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAnnouncements()
        {
            return Ok(await _mediator.Send(new GetAnnouncementsQuery()));
        }

        [AllowAnonymous]
        [HttpGet("Lite")]
        public async Task<IActionResult> GetLiteAnnouncements()
        {
            return Ok(await _mediator.Send(new GetLiteAnnouncementsQuery()));
        }

        [HttpGet("ByTitle")]
        public async Task<IActionResult> GetAnnouncementsByTitle([FromQuery] GetAnnouncementsByTitleQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("ByCreatorId")]
        public async Task<IActionResult> GetAnnouncementsByCreatorId([FromQuery] GetAnnouncementsByCreatorIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetAnnouncementById([FromQuery] GetAnnouncementByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("Similar")]
        public async Task<IActionResult> GetSimilarAnnouncements([FromQuery] GetSimilarAnnouncementsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementCommand command)
        {
            command.CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] UpdateAnnouncementCommand command)
        {
            var query = new GetAnnouncementByIdQuery(command.Id);
            var announcement = await _mediator.Send(query);

            if (announcement.CreatorId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid(); //Only creator can edit the announcement
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAnnouncement([FromQuery] DeleteAnnouncementCommand command)
        {
            var query = new GetAnnouncementByIdQuery(command.Id);
            var announcement = await _mediator.Send(query);

            if (announcement.CreatorId != User.FindFirstValue(ClaimTypes.NameIdentifier) && !User.IsInRole("Admin"))
            {
                return Forbid(); //You can delete only your announcements if you are not admin
            }

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
