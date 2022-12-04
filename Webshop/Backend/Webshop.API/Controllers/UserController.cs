using Webshop.DAL.Types;
using Webshop.BLL.Infrastructure.Commands;
using Webshop.BLL.Infrastructure.DataTransferObjects;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.BLL.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Webshop.DAL.Domain;

namespace Webshop.API.Controllers
{
    /// <summary>
    /// Controller for users
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Roles = RoleTypes.All)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="userid">Id of the user</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Minimal value of a user</returns>
        [HttpGet("simple/{userid}")]
        public async Task<ActionResult<ProfileWithNameViewModel>> GetUserByIdAsync(string userid, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery(userid);
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Get profile data
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Profile data of the user</returns>
        [HttpGet("profile")]
        public async Task<ActionResult<ProfileViewModel>> GetProfileAsync(CancellationToken cancellationToken)
        {
            var query = new GetProfileQuery();
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Get full profile data
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Full profile data of the user</returns>
        [HttpGet("full-profile")]
        public async Task<ActionResult<ProfileWithNameViewModel>> GetFullProfileAsync(CancellationToken cancellationToken)
        {
            var query = new GetFullProfileQuery();
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Get the id of the actual user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Id of the actual user</returns>
        [HttpGet("actual-id")]
        public async Task<ActionResult<string>> GetAccountsByUserAsync(CancellationToken cancellationToken)
        {
            var query = new GetActualUserIdQuery();
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Get users with the given role
        /// </summary>
        /// <param name="role">Searched role</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Users with the given role</returns>
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpGet("role/{role}")]
        public async Task<ActionResult<IEnumerable<UserNameViewModel>>> GetUsersByRoleAsync(string role, CancellationToken cancellationToken)
        {
            var query = new GetUsersByRoleQuery(role);
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Edit actual user data
        /// </summary>
        /// <param name="userDTO">values to edit</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Success</returns>
        [HttpPut("edit")]
        public async Task<ActionResult<bool>> EditUserAsync([FromBody] EditUserDto userDTO, CancellationToken cancellationToken)
        {
            var command = new EditUserCommand(userDTO);
            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="userDTO">values to edit</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Success</returns>
        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<ActionResult<bool>> RegisterUserAsync([FromBody] RegisterUserDto userDTO, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(userDTO);
            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Edit roles of users
        /// </summary>
        /// <param name="userRoleDTO">user to edit</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Success</returns>
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpPost("role/change")]
        public async Task<ActionResult> EditUserRolesAsync([FromBody] EditUserRoleDto userRoleDTO, CancellationToken cancellationToken)
        {
            var command = new EditUserRoleCommand(userRoleDTO);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet("inventory")]
        public async Task<IActionResult> GetUserInventory([FromQuery] GetCaffsDto caffsDTO, CancellationToken cancellationToken)
        {
            var query = new GetBoughtCaffsQuery(caffsDTO, User);
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
