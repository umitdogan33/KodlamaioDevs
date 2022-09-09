using Application.Features.Technologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetAllTechnologies
{
    public class GetAllTechnologyQuery:IRequest<IList<TechnologyGetAllDto>>
    {
    }
}
