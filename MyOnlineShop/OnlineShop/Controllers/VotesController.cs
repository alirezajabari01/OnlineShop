using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.VotesDTO;
using OnlineShop.Core.Security;
using OnlineShop.Core.Security.Users;
using OnlineShop.Core.SeedData;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/Products/{id}/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly IUserContext userContext;

        public VotesController(IVoteService voteService, IUserContext userContext)
        {
            this.voteService = voteService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductVotes(string id)
        {
            return Ok(await voteService.GetAllProductVotesAsync(id));
        }

        [SecurityFilter(AuthorizationRoleClaim.UserClaimValue)]
        [HttpPost]
        public async Task<IActionResult> CreateVote([FromForm]CreateVoteDTO dTO)
        {
            return Created("", await voteService.CreateVoteAsync(dTO,userContext.UserId));
        }
    }
}
