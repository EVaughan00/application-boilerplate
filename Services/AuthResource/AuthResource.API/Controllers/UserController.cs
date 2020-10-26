using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using AuthResource.API.Commands;
using AuthResource.API.Queries;
using AuthResource.Domain;
using System.Collections.Generic;
using AuthResource.API.DTO;

namespace AuthResource.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
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

        [HttpGet("Users")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAll()
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
