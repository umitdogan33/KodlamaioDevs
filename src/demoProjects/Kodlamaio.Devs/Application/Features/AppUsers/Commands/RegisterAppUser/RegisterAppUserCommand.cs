using Application.Services.Features.AppUsers.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterAppUserCommand :UserForRegisterDto, IRequest<RegisteredAppUserDto>
    {
        public string GithubProfile { get; set; }
    }
}
