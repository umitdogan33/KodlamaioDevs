using Application.Features.Technologies.Models;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetAllByPageTechnology
{
    public class GetAllByPageTechnologyQuery:IRequest<GetAllByPageTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
