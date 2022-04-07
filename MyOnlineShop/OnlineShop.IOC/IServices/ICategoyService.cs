using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.CategoriesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface ICategoyService
    {
        Task<List<ShowCategiroesDTO>> GetCategiriesAsync();
        Task<ShowCategiroesDTO> GetCategoryByIdAsync(string id);
        Task<int> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<string> UpdateCategoryAsync(UpdateCategoryDTO categoryDTO);
        Task<bool> DeActiveCategoryAsync(string id);
    }
}
