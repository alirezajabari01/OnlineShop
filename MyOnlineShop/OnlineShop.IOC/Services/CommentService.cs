using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO.CommentsDTO;
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
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> repository;
        private readonly IMapper mapper;

        public CommentService(IRepository<Comment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> CreateCommentAsync(CreateCommentDTO comment, string userId)
        {
            string outPut = "انجام نشد";
            if (!string.IsNullOrEmpty(userId) && comment != null)
            {
                var mappedComment = mapper.Map<Comment>(comment);
                mappedComment.UserId = userId;
                var createdResult = await repository.CreateAsync(mappedComment);
                if (createdResult > 0)
                {
                    outPut = "انجام شد";
                }
            }
            return outPut;
        }

        public async Task<List<AllCommentsDTO>> GetProductCommentsAsync(string productId)
        {
            var product_commnets = await repository.GetAll()
                .Where(w => w.ProductId == productId)
                .ToListAsync();
            foreach (var cm in product_commnets)
            {
                var replies = product_commnets.Where(w => w.ParentId == cm.Id).ToList();
                if (replies.Any())
                {
                    cm.Replies = replies;
                }
            }
            var mappedComments = mapper.Map<List<AllCommentsDTO>>(product_commnets);
            return mappedComments.Where(s=>s.ParentId == null).ToList();
        }
    }
}
