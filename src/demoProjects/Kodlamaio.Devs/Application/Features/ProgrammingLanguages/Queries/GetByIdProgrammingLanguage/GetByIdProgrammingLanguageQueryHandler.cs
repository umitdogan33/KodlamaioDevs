using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetByIdProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository repository;
        private readonly IMapper mapper;

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            //var mappedData = mapper.Map<ProgrammingLanguage>(request);
            var data = await repository.GetAsync(p => p.Id == request.Id);
            var mappedData = mapper.Map<GetByIdProgrammingLanguageDto>(data);
            return mappedData;
        }
    }
}
