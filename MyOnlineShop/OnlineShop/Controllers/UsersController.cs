using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.Core.DTO.UsersDTO;
using OnlineShop.Core.Security;
using OnlineShop.Core.Security.Users;
using OnlineShop.Infrastructor.DTO.RolesDTO;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUserContext userContext;

        public UsersController(IUserService userService, IUserContext userContext)
        {
            this.userService = userService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            return Ok(await userService.GetUserByIdAsync(id));
        }

        [SecurityFilter("User.Create")]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            return Created("", await userService.CreateUserAsync(userDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserDTO userDTO)
        {
            return Ok(await userService.UpdateUserAsync(userDTO));
        }
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserDTO addRoleToUserDTO)
        {

            return Created("", await userService.AddRoleToUserAsync(addRoleToUserDTO));
        }
    }
}
