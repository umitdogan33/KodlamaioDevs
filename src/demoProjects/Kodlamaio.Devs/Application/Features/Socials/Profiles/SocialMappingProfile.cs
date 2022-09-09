using Application.Features.ProgrammingLanguages.Models;
using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Commands.UpdateSocial;
using Application.Features.Socials.Dtos;
using Application.Features.Socials.Models;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Profiles
{
    public class SocialMappingProfile : Profile
    {
        public SocialMappingProfile()
        {
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
            CreateMap<Social, CreatedSocialDto>().ReverseMap();

            CreateMap<Social, UpdateSocialCommand>().ReverseMap();
            CreateMap<Social, UpdatedSocialDto>().ReverseMap();

            CreateMap<IPaginate<Social>, GetListSocialModel>().ReverseMap();
            CreateMap<Social, GetListSocialDto>().ForMember(m => m.UserName, opt => opt.MapFrom(m => m.AppUser.FirstName)).ReverseMap();
        }
    }
}
