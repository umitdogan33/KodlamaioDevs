using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Technologies.Dtos;

namespace Application.Features.Technologies.Commands.CreateTechlonogy
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private readonly ITechlonogyRepository repository;
        private readonly IMapper mapper;

        public CreateTechnologyCommandHandler(ITechlonogyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            var mappedData = mapper.Map<Technology>(request);
            var savedData =await repository.AddAsync(mappedData);
            var mappedDataDto = mapper.Map<CreatedTechnologyDto>(savedData);

            return mappedDataDto;
        }
    }
}
