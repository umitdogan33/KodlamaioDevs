using Application.Features.ProgrammingLanguages.Commands.UpdateBrand;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository repository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository repository)
        {
            this.repository = repository;
        }

        public async Task ProgrammingLnaguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }

        public async Task ProgrammingLanguageDelete(int id)
        {
            var result = await repository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("delete data not found");
        }

        public async Task ProgrammingLanguageUpdate(ProgrammingLanguage result)
        {
            if (result == null) throw new BusinessException("update data not found");
        }
    }
    }
