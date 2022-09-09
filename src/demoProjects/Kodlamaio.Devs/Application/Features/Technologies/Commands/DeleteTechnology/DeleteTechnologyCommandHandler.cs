using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly ITechlonogyRepository _repository;
        private readonly IMapper _mapper;

        public DeleteTechnologyCommandHandler(ITechlonogyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            var findData = await _repository.GetAsync(p=>p.Id == request.Id);
            var deletedData = _repository.Delete(findData);
            var mappedDtoData = _mapper.Map<DeletedTechnologyDto>(deletedData);
            return mappedDtoData;
        }
    }
}
