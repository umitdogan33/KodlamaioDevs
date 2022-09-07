using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateBrand
{
    public class UpdateProgrammingLanguageCommandHandler:IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository repository;
        private readonly IMapper mapper;
        private readonly ProgrammingLanguageBusinessRules businessRules;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.businessRules = businessRules;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            var fetchData = await repository.GetAsync(p => p.Id == request.Id);
            await businessRules.ProgrammingLanguageUpdate(fetchData);
            fetchData.Name = request.Name;
            var update = await repository.UpdateAsync(fetchData);
            var mappedUpdatedData = mapper.Map<UpdatedProgrammingLanguageDto>(update);
            return mappedUpdatedData;
        }
    }
}
