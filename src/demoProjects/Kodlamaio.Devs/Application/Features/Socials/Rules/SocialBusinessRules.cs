﻿using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Rules
{
    public class SocialBusinessRules
    {
        public async Task isbedatawhendelete(Social social) {
            if (social == null)  throw new BusinessException("data is nor found");
        }
    }
}
