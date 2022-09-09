using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Rules
{
    public class AppUserBusinessRule
    {
        private readonly IAppUserRepository _repository;

        public AppUserBusinessRule(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task DuplicateEmail(string email) {
            var data = await _repository.GetAsync(p=>p.Email == email);
            if (data != null) throw new BusinessException("duplicate email");

        }

        public async Task CheckEmailAndPassword(string password,User user) {

            if (user == null) throw new BusinessException("email is not found");

            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Password is not match");
        }
    }
}
