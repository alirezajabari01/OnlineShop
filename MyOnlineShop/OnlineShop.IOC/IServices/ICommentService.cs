using OnlineShop.Core.DTO.CommentsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface ICommentService
    {
        Task<List<AllCommentsDTO>> GetProductCommentsAsync(string productId);
        Task<string> CreateCommentAsync(CreateCommentDTO comment, string userId);
    }
}
