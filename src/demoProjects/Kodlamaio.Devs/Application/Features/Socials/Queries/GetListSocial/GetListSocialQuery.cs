using Application.Features.Socials.Dtos;
using Application.Features.Socials.Models;
using Core.Application.Pipelines.Authentication;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Queries.GetListSocial
{
    public class GetListSocialQuery:IRequest<GetListSocialModel>,IAuthRequest
    {
        public PageRequest PageRequest { get; set; }
    }
}
