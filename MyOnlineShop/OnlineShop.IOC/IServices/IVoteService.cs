using OnlineShop.Core.DTO.ProductsDTO;
using OnlineShop.Core.DTO.VotesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IVoteService
    {
        Task<List<AllProductVotesDTO>> GetAllProductVotesAsync(string productId);
        Task<string> CreateVoteAsync(CreateVoteDTO createVoteDTO, string userId);
    }
}
