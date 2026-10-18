
using CQRS_Project.Application.Users.Commands.Register;
using CQRS_Project.Application.Users.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterCommand command,
            CancellationToken cancellationToken)
        {
            var userId = await _sender.Send(
                command, cancellationToken);

            return Ok(new
            {
                Message = "User registered successfully.",
                UserId = userId
            });
        }





        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginCommand command,
            CancellationToken cancellationToken)
        {
            var token = await _sender.Send(
                command, cancellationToken);

            return Ok(new
            {
                AccessToken = token,
                TokenType = "Bearer"
            });
        }

    }
}
