using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.ProductsDTO;
using OnlineShop.Core.Security;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public AdminProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        [SecurityFilter("Admin.Product")]
        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> GetAllProducts(int skip, int take)
        {
            return Ok(await productsService.GetAllProductsAsync(skip, take));
        }
        [HttpPost]
        //[SecurityFilter("Admin.Product")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO createProductDTO)
        {
            return Created("", await productsService.CreateProductAsync(createProductDTO));
        }
        [HttpPut]
        [SecurityFilter("Admin.Product")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDTO updateProductDTO)
        {
            return Ok(await productsService.UpdateProductAsync(updateProductDTO));
        }
        [HttpGet("{id}")]
        [SecurityFilter("Admin.Product")]
        public async Task<IActionResult> GetProductById(string id)
        {
            return Ok(await productsService.GetProductByIdAsync(id));
        }

        [HttpPost("FiltredProducts/{skip}/{take}")]
        public IActionResult FiltredProducts([FromForm]FilterProductsDTO dTO, int skip, int take)
        {
            return Ok(productsService.GetFiltredProducts(dTO, skip, take));
        }
        [HttpGet("PopularVoted")]
        public IActionResult GetPopularVoted()
        {
            return Ok(productsService.GetPopularByVotes());
        }
        [HttpGet("PopularRated")]
        public IActionResult GetPopularRated()
        {
            return Ok(productsService.GetPopularByRates());
        }
    }
}
