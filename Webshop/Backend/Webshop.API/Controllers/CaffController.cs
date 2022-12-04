using Webshop.BLL.Infrastructure.Commands;
using Webshop.BLL.Infrastructure.DataTransferObjects;
using Webshop.BLL.Infrastructure.Queries;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.DAL.Configurations.Interfaces;
using Webshop.DAL.Types;
using IdentityServer4.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Net.Sockets;

namespace Webshop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Roles = RoleTypes.All)]
    public class CaffController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebshopConfigurationService _config;

        public CaffController(IMediator mediator, IWebshopConfigurationService config)
        {
            _mediator = mediator;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<EnumerableWithTotalViewModel<CaffListViewModel>>> GetCaffList(
            [FromQuery] GetCaffsDto dto,
            CancellationToken cancellationToken)
        {
            var query = new GetCaffListQuery(dto, User);
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        [HttpGet("{caffId}")]
        public async Task<ActionResult<CaffListViewModel>> GetCaffDetails(
            [FromRoute] Guid caffId,
            CancellationToken cancellationToken)
        {
            var query = new GetCaffDetailsQuery(caffId, User);
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        [HttpPost("{caffId}/comments/add")]
        public async Task<IActionResult> PostComment(
            [FromRoute] Guid caffId,
            [FromForm] PostCommentDto dto,
            CancellationToken cancellationToken)
        {
            var command = new PostCommentCommand(caffId, User, dto);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{caffId}/comments/remove")]
        public async Task<IActionResult> DeleteComment(
            [FromRoute] Guid caffId,
            [FromBody] RemoveCommentDto dto,
            CancellationToken cancellationToken)
        {
            var command = new RemoveCommentCommand(caffId, User, dto);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> UploadCaff([FromForm] UploadCaffDto dto, CancellationToken cancellationToken)
        {
            var command = new UploadCaffCommand(dto, HttpContext.User);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{caffId}")]
        public async Task<IActionResult> DeleteCaff([FromRoute] Guid caffId, CancellationToken cancellationToken)
        {
            var command = new DeleteCaffCommand(caffId, HttpContext.User);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost("checkout/{caffId}")]
        public async Task<IActionResult> BuyCaff([FromRoute] Guid caffId, CancellationToken cancellationToken)
        {
            var command = new BuyCaffCommand(caffId, HttpContext.User);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet("download/{caffId}")]
        public async Task<IActionResult> DownloadCaff([FromRoute] Guid caffId, CancellationToken cancellationToken)
        {
            var command = new GetCaffDownloadQuery(caffId, HttpContext.User);
            return File(await _mediator.Send(command, cancellationToken), "application/octet-stream", fileDownloadName: $"{DateTime.Now}.caff");
        }

        [HttpPut("{caffId}")]
        public async Task<IActionResult> EditCaffData([FromRoute] Guid caffId, [FromBody] EditCaffDto dto, CancellationToken cancellationToken)
        {
            var command = new EditCaffDataCommand(caffId, dto, HttpContext.User);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            return Ok(new { MaxUploadSize = _config.GetMaxUploadSize(), MaxUploadCount = _config.GetMaxUploadCount() });
        }
    }
}
