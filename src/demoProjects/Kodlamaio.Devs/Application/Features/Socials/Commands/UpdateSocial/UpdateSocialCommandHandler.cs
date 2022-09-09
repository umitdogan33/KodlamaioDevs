using Application.Features.Socials.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.UpdateSocial
{
    public class UpdateSocialCommandHandler : IRequestHandler<UpdateSocialCommand, UpdatedSocialDto>
    {
        private readonly ISocialRepository _socialRepository;
        private readonly IMapper _mapper;

        public UpdateSocialCommandHandler(ISocialRepository socialRepository, IMapper mapper)
        {
            _socialRepository = socialRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedSocialDto> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var mappedData = _mapper.Map<Social>(request);
            var updateData = await _socialRepository.UpdateAsync(mappedData);
            var mappedUpdatedData = _mapper.Map<UpdatedSocialDto>(updateData);
            return mappedUpdatedData;
        }
    }
}
