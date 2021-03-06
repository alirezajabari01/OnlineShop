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
            categoryDTO.Id = Guid.NewGuid().ToString();
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
            var allCategories = await repository.GetAll()
                .ToListAsync();

            var dtoList = new List<ShowCategiroesDTO>();
            foreach (var category in allCategories)
            {
                var dto = new ShowCategiroesDTO()
                {
                    ParentId = category.ParentId,
                    Id = category.Id,
                    Name = category.Name,
                };
                dtoList.Add(dto);
            }
            foreach (var category in dtoList)
            {
                var children = dtoList.Where(w => w.ParentId == category.Id).ToList();
                if (children.Any())
                {
                    category.Categories = children;
                }
            }
            return dtoList.Where(w => w.ParentId == null).ToList();
        }

        public async Task<ShowCategiroesDTO> GetCategoryByIdAsync(string id)
        {
            var category = await repository.GetAll()
                .Include(s => s.Categories)
                .SingleOrDefaultAsync(s => s.Id == id);
            return mapper.Map<ShowCategiroesDTO>(category);
        }

        public async Task<string> UpdateCategoryAsync(UpdateCategoryDTO categoryDTO)
        {
            string outPut = "انجام نشد";
            var category = await repository.GetByIdAsync(categoryDTO.Id);
            if (category != null)
            {
                category.Name = categoryDTO.Name;
                category.ParentId = categoryDTO.ParentId;
                category.IsActive = categoryDTO.IsActive;

                var updateResult = await repository.UpdateAsync(category);
                if (updateResult == 1)
                {
                    outPut = "انجام شد";
                }
            }
            return outPut;
        }
    }
}

