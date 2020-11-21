using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using AuthResource.API.Commands;
using AuthResource.API.Queries;
using System.Collections.Generic;
using AuthResource.API.DTO;
using Microsoft.AspNetCore.Authorization;

namespace AuthResource.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            try {
                var result = await _mediator.Send(command);

                return Ok(result);
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            try {
                var result = await _mediator.Send(command);

                return Ok(result);
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("details")]
        [Authorize]
        public async Task<ActionResult<List<UserResponseDTO>>> Details()
        {
            try {
                var result = await _mediator.Send(new UserQuery());
                
                return Ok(result);
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }
    }
}
