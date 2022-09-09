using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommandHandler:IRequestHandler<UpdateTechnologyCommand,UpdatedTechnologyDto>
{
    private readonly ITechlonogyRepository _repository;
    private readonly IMapper _mapper;
    
    public UpdateTechnologyCommandHandler(ITechlonogyRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    
    public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
    {
        var mappedUpdateData = _mapper.Map<Technology>(request);
        var updatedData = await _repository.UpdateAsync(mappedUpdateData);
        var mappedUpdatedDtoData = _mapper.Map<UpdatedTechnologyDto>(updatedData);
        return mappedUpdatedDtoData;
    }
}