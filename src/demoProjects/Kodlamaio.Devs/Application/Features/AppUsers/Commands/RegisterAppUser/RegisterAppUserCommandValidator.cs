using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterAppUserCommandValidator : AbstractValidator<RegisterAppUserCommand>
    {
        public RegisterAppUserCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.GithubProfile).NotEmpty();

        }
    }
}
