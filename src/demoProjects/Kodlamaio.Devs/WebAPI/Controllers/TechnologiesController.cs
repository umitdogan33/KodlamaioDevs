using Application.Features.Technologies.Commands.CreateTechlonogy;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Queries.GetAllByPageTechnology;
using Application.Features.Technologies.Queries.GetAllTechnologies;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateTechnologyCommand command) {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var data = await Mediator.Send(new GetAllTechnologyQuery());
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByPage([FromQuery] PageRequest pageRequest)
        {
            var data = await Mediator.Send(new GetAllByPageTechnologyQuery() { PageRequest = pageRequest});
            return Ok(data);
        }
    }
}
