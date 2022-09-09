using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Commands.UpdateSocial;
using Application.Features.Socials.Queries.GetListSocial;
using Application.Services.Features.Socials.Commands.DeleteSocial;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class SocialsController:BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateSocialCommand command) {
            var result =await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] int pageIndex, int pageSize)
        {
            PageRequest pageRequest = new() { Page = pageIndex, PageSize = pageSize };
            var result = await Mediator.Send(new GetListSocialQuery() { PageRequest = pageRequest});
            return Ok(result);
        }
    }
}
