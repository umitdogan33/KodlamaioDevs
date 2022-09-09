using Application.Features.Socials.Dtos;
using Application.Features.Socials.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Queries.GetListSocial
{
    public class GetListSocialQueryHandler : IRequestHandler<GetListSocialQuery, GetListSocialModel>
    {
        private readonly ISocialRepository _repository;
        private readonly IMapper _mapper;

        public GetListSocialQueryHandler(ISocialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetListSocialModel> Handle(GetListSocialQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize,include: m=>m.Include(m=>m.AppUser));
            var mappedDtoData = _mapper.Map<GetListSocialModel>(data);
            return mappedDtoData;
        }
    }
}
