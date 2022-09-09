using Application.Services.Features.Socials.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialCommand:IRequest<DeletedSocialDto>
    {
        public int Id { get; set; }
    }
}
