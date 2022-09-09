using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Commands.LoginAppUser
{
    public class LoginAppUserCommandValidator : AbstractValidator<LoginAppUserCommand>
    {
        public LoginAppUserCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Password).NotEmpty();

        }
    }
}
