using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
