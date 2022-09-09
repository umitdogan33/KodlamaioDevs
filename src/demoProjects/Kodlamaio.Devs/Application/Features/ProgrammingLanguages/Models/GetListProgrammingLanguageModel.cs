using Application.Features.ProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class GetListProgrammingLanguageModel
    {
        public IList<GetListProgrammingLanguageDto> Items { get; set; }
    }
}
