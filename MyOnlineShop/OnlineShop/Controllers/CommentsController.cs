using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.DTO.CommentsDTO;
using OnlineShop.Core.Security;
using OnlineShop.Core.Security.Users;
using OnlineShop.Core.SeedData;
using OnlineShop.IOC.IServices;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/Products/{id}/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IUserContext userContext;

        public CommentsController(ICommentService commentService, IUserContext userContext)
        {
            this.commentService = commentService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments(string id)
        {
            return Ok(await commentService.GetProductCommentsAsync(id));
        }

        [SecurityFilter(AuthorizationRoleClaim.UserClaimValue)]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromForm]CreateCommentDTO dTO)
        {
            return Created("",await commentService.CreateCommentAsync(dTO, userContext.UserId));
        }
    }
}
