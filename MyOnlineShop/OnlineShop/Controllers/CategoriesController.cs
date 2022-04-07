using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.CategoriesDTO;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoyService categoyService;

        public CategoriesController(ICategoyService categoyService)
        {
            this.categoyService = categoyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await categoyService.GetCategiriesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryDTO categoryDTO)
        {
            return Created("", await categoyService.CreateCategoryAsync(categoryDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDTO categoryDTO)
        {
            return Ok(await categoyService.UpdateCategoryAsync(categoryDTO));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            return Ok(await categoyService.GetCategoryByIdAsync(id));
        }
    }
}
