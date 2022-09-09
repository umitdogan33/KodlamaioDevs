using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetAllByPageTechnology
{
    public class GetAllByPageTechnologyQueryHandler : IRequestHandler<GetAllByPageTechnologyQuery, GetAllByPageTechnologyModel>
    {
        private readonly ITechlonogyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllByPageTechnologyQueryHandler(ITechlonogyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAllByPageTechnologyModel> Handle(GetAllByPageTechnologyQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize,include: m=>m.Include(m=>m.ProgrammingLanguage));
            var mappedData = _mapper.Map<GetAllByPageTechnologyModel>(data);
            return mappedData;
        }
    }
}
