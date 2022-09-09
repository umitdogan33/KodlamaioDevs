using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialCommandValidator : AbstractValidator<CreateSocialCommand>
    {
        public CreateSocialCommandValidator()
        {
            RuleFor(p => p.AppUserId).NotEmpty();
            RuleFor(p => p.GithubLink).NotEmpty();
        }
    }
}
