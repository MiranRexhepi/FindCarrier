using FindCarrier.Commands.Authenticate;
using FindCarrier.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FindCarrier.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var login = await _mediator.Send(new Login.Command
            {
                Model = model
            });

            if(login is bool)
                return Unauthorized();

            return Ok(login);   
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserViewModel model)
        {
            var register = await _mediator.Send(new Register.Command
            {
                Model = model
            });

            if (register.Status.Equals("Error"))
                return StatusCode(StatusCodes.Status500InternalServerError, register);

            return Ok(register);
        }
    }
}