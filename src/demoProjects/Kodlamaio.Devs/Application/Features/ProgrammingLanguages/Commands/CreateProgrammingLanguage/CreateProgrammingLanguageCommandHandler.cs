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

namespace Application.Features.ProgrammingLanguages.Commands.CreateBrand
{
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository repository;
        private readonly IMapper mapper;
        private readonly ProgrammingLanguageBusinessRules businessRules;

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.businessRules = businessRules;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await businessRules.ProgrammingLnaguageNameCanNotBeDuplicatedWhenInserted(request.Name);
            var mappedData = mapper.Map<ProgrammingLanguage>(request);
            var data = await repository.AddAsync(mappedData);
            var mappedDtoData = mapper.Map<CreatedProgrammingLanguageDto>(data);
            return mappedDtoData;

        }
    }
}
