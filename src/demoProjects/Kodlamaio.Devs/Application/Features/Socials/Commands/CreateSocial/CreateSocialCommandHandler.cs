using Application.Features.Socials.Dtos;
using Application.Features.Socials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialCommandHandler : IRequestHandler<CreateSocialCommand, CreatedSocialDto>
    {
        private readonly ISocialRepository _socialRepository;
        private readonly IMapper _mapper;
        private readonly SocialBusinessRules _rules;
        public CreateSocialCommandHandler(ISocialRepository socialRepository, IMapper mapper, SocialBusinessRules rules)
        {
            _socialRepository = socialRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<CreatedSocialDto> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            await _rules.domainCheck(request.GithubLink);
            var mappedData = _mapper.Map<Social>(request);
            var createData = await _socialRepository.AddAsync(mappedData);
            var mappedDtoData = _mapper.Map<CreatedSocialDto>(createData);
            return mappedDtoData;
        }
    }
}
