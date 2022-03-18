using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllAsync());
        }

        [HttpPost("IsUserNameExist")]
        public async Task<IActionResult> IsUserNameExist(string username)
        {
            return Ok(await userService.IsUserNameExistAsync(username));
        }

        [HttpPost("IsPhoneNumberExist")]
        public async Task<IActionResult> IsPhoneNumberExist(string phoenumber)
        {
            return Ok(await userService.IsPhoneNumberExistAsync(phoenumber));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            return Ok(await userService.GetUserByIdAsync(id));
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            await userService.CreateUserAsync(userDTO);
            return Created("", null);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserDTO userDTO)
        {
            return Ok(await userService.UpdateUserAsync(userDTO));
        }
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser()
        {

            return Created("", null);
        }
    }
}
