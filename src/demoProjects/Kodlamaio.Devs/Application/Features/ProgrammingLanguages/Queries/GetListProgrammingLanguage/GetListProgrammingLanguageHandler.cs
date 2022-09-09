using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
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
    public class GetListProgrammingLanguageHandler : IRequestHandler<GetListProgrammingLanguageQuery, IList<GetListProgrammingLanguageDto>>
    {
        private readonly IMapper mapper;
        private readonly IProgrammingLanguageRepository repository;

        public GetListProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IList<GetListProgrammingLanguageDto>> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            var totalProductCount = await repository.GetAllAsync();
            var mappedData = mapper.Map<IList<GetListProgrammingLanguageDto>>(totalProductCount);
            return mappedData;
            //var data = totalProductCount.Count();
            //return new()
            //{
            //    ProgrammingLanguages = data,
            //    Count = data.Count()
            //};
        }
    }
}
