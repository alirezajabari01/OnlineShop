using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.RoleClaimsDTO;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/Roles/{id}/[controller]")]
    [ApiController]
    public class RoleClaimsController : ControllerBase
    {
        private readonly IRoleClaimService roleClaimService;

        public RoleClaimsController(IRoleClaimService roleClaimService)
        {
            this.roleClaimService = roleClaimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleClaims(string id)
        {
            return Ok(await roleClaimService.GetAllRoleClaimsAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleClaim([FromForm]RoleClaimDTO dto)
        {
            return Created("",await roleClaimService.CreateRoleClaimAsync(dto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoleClaim([FromForm] UpdateRoleClaimDTO dto)
        {
            return Ok(await roleClaimService.UpdateRoleClaimAsync(dto));
        }
    }
}
