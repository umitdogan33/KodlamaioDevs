using Application.Features.Technologies.Dtos;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>
{
    public int Id { get; set; }
    public string TechnologyName { get; set; }
    public int ProgrammingLanguageId { get; set; }
}