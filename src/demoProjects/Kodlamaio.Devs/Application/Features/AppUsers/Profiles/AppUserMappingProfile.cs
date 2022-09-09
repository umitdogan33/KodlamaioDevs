using Application.Features.AppUsers.Dtos;
using Application.Services.Features.AppUsers.Dtos;
using AutoMapper;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUsers.Profiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AccessToken,RegisteredAppUserDto>().ReverseMap();
            CreateMap<AccessToken, LoginedAppUserDto>().ReverseMap();
        }
    }
}
