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

namespace Application.Features.ProgrammingLanguages.Commands.DeleteBrand
{
    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository programmingLanguageRepository;
        private readonly IMapper mapper;
        private readonly ProgrammingLanguageBusinessRules businessRules;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
        {
            this.programmingLanguageRepository = programmingLanguageRepository;
            this.mapper = mapper;
            this.businessRules = businessRules;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await businessRules.ProgrammingLanguageDelete(request.Id);
            var foundData = await programmingLanguageRepository.GetAsync(p=>p.Id == request.Id);
            var deletedData =  await programmingLanguageRepository.DeleteAsync(foundData);
            var deletedDataDto = mapper.Map<DeletedProgrammingLanguageDto>(deletedData);
            return deletedDataDto;

        }
    }
}
