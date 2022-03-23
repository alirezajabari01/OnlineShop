using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO.CategoriesDTO;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class CategoyService : ICategoyService
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CategoyService(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var mappedCategory = mapper.Map<Category>(categoryDTO);
            var createResult = await repository.CreateAsync(mappedCategory);
            return createResult;
        }

        public async Task<bool> DeActiveCategoryAsync(string id)
        {
            bool outPut = false;
            if (!string.IsNullOrEmpty(id))
            {
                var category = await repository.GetByIdAsync(id);
                if (category != null)
                {
                    category.IsActive = false;
                    await repository.UpdateAsync(category);
                    outPut = true;
                }
            }
            return outPut;
        }

        public async Task<List<ShowCategiroesDTO>> GetCategiriesAsync()
        {
            var cat = await repository.GetAll()
                .ToListAsync();
            var dtoList = new List<ShowCategiroesDTO>();
            foreach (var category in cat)
            {
                if (category.Categories != null)
                {
                    var c = new ShowCategiroesDTO()
                    {
                        ParentId = category.ParentId,
                        Id = category.Id,
                        Name = category.Name,
                        SubCategiries = category.Categories
                        .Select(c => new ShowCategiroesDTO()
                        {
                            Id = c.Id,
                            ParentId = c.ParentId,
                            Name = c.Name,
                        }).ToList()
                    };
                    while (c.SubCategiries.Any())
                    {
                        c.SubCategiries.Add(new ShowCategiroesDTO()
                        {
                            SubCategiries = c.SubCategiries,
                            Id = c.Id,
                            Name = c.Name,
                            ParentId = c.ParentId,
                        });
                    }
                    dtoList.Add(c);
                }
            };
            return dtoList;

        }



        public async Task<CategoryDTO> GetCategoryByIdAsync(string id)
        {
            var category = await repository.GetByIdAsync(id);
            return mapper.Map<CategoryDTO>(category);
        }

        public Task<int> UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}

