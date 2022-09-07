using Application.Features.ProgrammingLanguages.Commands.CreateBrand;
using Application.Features.ProgrammingLanguages.Commands.DeleteBrand;
using Application.Features.ProgrammingLanguages.Commands.UpdateBrand;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListBrand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var data = await Mediator.Send(new GetListProgrammingLanguageQuery());
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProgrammingLanguageQuery command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CreateProgrammingLanguageCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(DeleteProgrammingLanguageCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UpdateProgrammingLanguageCommand command)
        {
            var data = await Mediator.Send(command);
            return Ok(data);
        }
    }
}
