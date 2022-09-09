using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetAllTechnologies
{
    public class GetAllTechnologyQueryHandler : IRequestHandler<GetAllTechnologyQuery, IList<TechnologyGetAllDto>>
    {
        private ITechlonogyRepository _repository;
        private IMapper _mapper;

        public GetAllTechnologyQueryHandler(ITechlonogyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<TechnologyGetAllDto>> Handle(GetAllTechnologyQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync(include: m => m.Include(c => c.ProgrammingLanguage));
            var mappedData = _mapper.Map<IList<TechnologyGetAllDto>>(data);
            return mappedData;
        }
    }
}
