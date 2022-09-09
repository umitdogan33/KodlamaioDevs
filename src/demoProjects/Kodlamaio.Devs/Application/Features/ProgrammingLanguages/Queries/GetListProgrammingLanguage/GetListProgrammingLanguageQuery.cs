using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListBrand
{
    public class GetListProgrammingLanguageQuery:IRequest<IList<GetListProgrammingLanguageDto>>
    {

    }
}
