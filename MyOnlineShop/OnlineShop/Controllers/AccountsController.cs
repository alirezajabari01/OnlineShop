using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.UsersDTO;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost("CheckUserNameAsync")]
        public async Task<IActionResult> CheckUserName([FromForm] string userName)
        {
            return Ok(await _accountsService.CheckUserNameAsync(userName));
        }

        [HttpPost("CheckPhoneNumber")]
        public async Task<IActionResult> CheckPhoneNumber([FromForm] string phoneNumber)
        {
            return Ok(await _accountsService.CheckPhoneNmberAsync(phoneNumber));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO)
        {
            return Ok(await _accountsService.LoginAsync(loginDTO));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            return Created("",await _accountsService.RegisterAsync(registerDTO));
        }

    }
}
