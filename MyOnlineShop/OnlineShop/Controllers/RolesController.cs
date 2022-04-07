using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.RolesDTO;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await roleService.GetAllRoles());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(string id)
        {
            return Ok(await roleService.GetRoleById(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> DeActiveRoleAsync(string id)
        {
            return Ok(await roleService.DeActiveRole(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync([FromForm] RoleDTO roleDTO)
        {
            return Ok(await roleService.CreateRole(roleDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoleAsync([FromForm] RoleDTO roleDTO)
        {
            return Ok(await roleService.UpdateRole(roleDTO));
        }
    }
}
