﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
    public class CreatedTechnologyDto
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
