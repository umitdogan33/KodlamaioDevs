using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Technologies.Dtos;

namespace Application.Features.Technologies.Commands.CreateTechlonogy
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
    {
        public string TechnologyName { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
