using Application.Features.AppUsers.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Commands.LoginAppUser
{
    public class LoginAppUserCommand:IRequest<LoginedAppUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
