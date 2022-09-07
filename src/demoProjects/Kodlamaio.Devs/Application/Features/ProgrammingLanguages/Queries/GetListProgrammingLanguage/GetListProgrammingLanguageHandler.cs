using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListBrand
{
    public class GetListProgrammingLanguageHandler : IRequestHandler<GetListProgrammingLanguageQuery, GetListProgrammingLanguageDto>
    {
        private readonly IMapper mapper;
        private readonly IProgrammingLanguageRepository repository;

        public GetListProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<GetListProgrammingLanguageDto> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            var totalProductCount = await repository.GetAllAsync();
            //var data = totalProductCount.Count();
            var data = totalProductCount;
            return new()
            {
                ProgrammingLanguages = data,
                Count = data.Count()
            };
        }
    }
}
