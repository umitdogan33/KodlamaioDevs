using Application.Features.Socials.Rules;
using Application.Services.Features.Socials.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialCommandHandler : IRequestHandler<DeleteSocialCommand, DeletedSocialDto>
    {
        private readonly ISocialRepository _socialRepository;
        private readonly IMapper _mapper;
        private readonly SocialBusinessRules _rule;
        public DeleteSocialCommandHandler(ISocialRepository socialRepository, IMapper mapper, SocialBusinessRules rule)
        {
            _socialRepository = socialRepository;
            _mapper = mapper;
            _rule = rule;
        }
        public async Task<DeletedSocialDto> Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
        {
           var data =  await _socialRepository.GetAsync(p=>p.Id == request.Id);
            await _rule.isbedatawhendelete(data);
            var DeletedData = await _socialRepository.DeleteAsync(data);
            var mappedDtoData = _mapper.Map<DeletedSocialDto>(DeletedData);
            return mappedDtoData;

           
        }
    }
}
