using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO.VotesDTO;
using OnlineShop.Domain.Entities.UserFeedBacks;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class VoteService : IVoteService
    {
        private readonly IRepository<ProductVote> repository;
        private readonly IMapper mapper;

        public VoteService(IRepository<ProductVote> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> CreateVoteAsync(CreateVoteDTO createVoteDTO, string userId)
        {
            string output = "انجام نشد";

            var anyVote = await repository.GetAll().Where(e => e.ProductId == createVoteDTO.ProductId
            && e.UserId == userId).SingleOrDefaultAsync();

            if (createVoteDTO != null)
            {
                var mappedVote = mapper.Map<ProductVote>(createVoteDTO);
                mappedVote.UserId = userId;

                if (anyVote == null)
                {
                    var createResult = await repository.CreateAsync(mappedVote);
                    if (createResult > 0)
                    {
                        output = "انجام شد";
                    }
                }
                else
                {
                    anyVote.Vote = createVoteDTO.Vote;
                    var updateResult =  await repository.UpdateAsync(anyVote);
                    if(updateResult > 0)
                    {
                        output = "انجام شد";
                    }
                }

            }
            return output;
        }

        public async Task<List<AllProductVotesDTO>> GetAllProductVotesAsync(string productId)
        {
            var productVotes = await repository.GetAll()
                .Where(e => e.ProductId == productId)
                .ToListAsync();

            return mapper.Map<List<AllProductVotesDTO>>(productVotes);
        }
    }
}
