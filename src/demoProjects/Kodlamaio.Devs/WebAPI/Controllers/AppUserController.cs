using Application.Features.AppUsers.Commands.LoginAppUser;
using Application.Features.AppUsers.Commands.RegisterAppUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AppUserController:BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterAppUserCommand command) {
            var sendedData = await Mediator.Send(command);
            return Ok(sendedData);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserCommand command)
        {
            var sendedData = await Mediator.Send(command);
            return Ok(sendedData);
        }
    }
}
