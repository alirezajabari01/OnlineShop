using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(await userService.GetAll());
        }

        [HttpPost("IsUserNameExist")]
        public async Task<IActionResult> IsUserNameExist(string username)
        {
            return Ok(await userService.IsUserNameExist(username));
        }

        [HttpPost("IsPhoneNumberExist")]
        public async Task<IActionResult> IsPhoneNumberExist(string phoenumber)
        {
            return Ok(await userService.IsPhoneNumberExist(phoenumber));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            return Ok(await userService.GetUserById(id));
        }

    }
}
