using Application.Features.Socials.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialCommand:IRequest<CreatedSocialDto>
    {
        public int AppUserId { get; set; }
        public string GithubLink { get; set; }

    }
}
