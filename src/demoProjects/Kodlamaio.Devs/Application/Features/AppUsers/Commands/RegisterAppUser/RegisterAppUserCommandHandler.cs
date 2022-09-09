using Application.Features.AppUsers.Rules;
using Application.Services.Features.AppUsers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommand, RegisteredAppUserDto>
    {
        private readonly IAppUserRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AppUserBusinessRule _rule;

        public RegisterAppUserCommandHandler(IAppUserRepository repository, IMapper mapper, IMediator mediator, ITokenHelper tokenHelper, AppUserBusinessRule rule)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
            _tokenHelper = tokenHelper;
            _rule = rule;
        }

        public async Task<RegisteredAppUserDto> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
        {
            await _rule.DuplicateEmail(request.Email);
            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

            Social social = new()
            {
                GithubLink = request.GithubProfile,
            };
            AppUser mappedUser = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AuthenticatorType = AuthenticatorType.None,
                Status = true,
                Socials = new List<Social>() { social }
            };

            await _repository.AddAsync(mappedUser);

            var token = _tokenHelper.CreateToken(mappedUser, new List<OperationClaim>());
            var mappedDto = _mapper.Map<RegisteredAppUserDto>(token);
            return mappedDto;
        }
    }
}
