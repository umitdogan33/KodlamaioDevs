using Application.Features.AppUsers.Dtos;
using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Commands.LoginAppUser
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, LoginedAppUserDto>
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AppUserBusinessRule _rule;

        public LoginAppUserCommandHandler(IAppUserRepository repository, IMapper mapper, ITokenHelper tokenHelper, AppUserBusinessRule rule)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _rule = rule;
        }

        public async Task<LoginedAppUserDto> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            var userData = await _repository.GetAsync(p => p.Email == request.Email);
            await _rule.CheckEmailAndPassword(request.Password,userData);
            
            var token = _tokenHelper.CreateToken(userData,new List<OperationClaim>());
            var mappedToken = _mapper.Map<LoginedAppUserDto>(token);
            return mappedToken;

        }
    }
}
