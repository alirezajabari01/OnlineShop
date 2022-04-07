using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.RatesDTO;
using OnlineShop.Core.Security;
using OnlineShop.Core.Security.Users;
using OnlineShop.Core.SeedData;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/Products/{id}/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRateService rateService;
        private readonly IUserContext userContext;

        public RatesController(IRateService rateService, IUserContext userContext)
        {
            this.rateService = rateService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await rateService.GetAllProductRatesAsync(id));
        }
        [SecurityFilter(AuthorizationRoleClaim.UserClaimValue)]
        [HttpPost]
        public async Task<IActionResult> CreateRate(CreateRateDTO dTO)
        {
            return Created("", await rateService.CreateRateAsync(dTO,userContext.UserId));
        }
    }
}
