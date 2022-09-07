using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class GetListProgrammingLanguageDto
    {
        public int Count { get; set; }
        public object ProgrammingLanguages { get; set; }
    }
}
