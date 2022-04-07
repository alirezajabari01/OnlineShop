using AutoMapper;
using OnlineShop.Core.DTO;
using OnlineShop.Core.DTO.CategoriesDTO;
using OnlineShop.Core.DTO.CommentsDTO;
using OnlineShop.Core.DTO.ProductsDTO;
using OnlineShop.Core.DTO.RatesDTO;
using OnlineShop.Core.DTO.RoleClaimsDTO;
using OnlineShop.Core.DTO.RolesDTO;
using OnlineShop.Core.DTO.UsersDTO;
using OnlineShop.Core.DTO.VotesDTO;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.UserFeedBacks;
using System.Collections.Generic;

namespace OnlineShop.IOC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ShowAllUsersDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
            CreateMap<ApplicationUser, RegisterDTO>().ReverseMap();
            CreateMap<ApplicationUser, LoginDTO>().ReverseMap();

            CreateMap<ApplicationRole, ShowAllRolesDTO>().ReverseMap();
            CreateMap<ApplicationRole, RoleDTO>().ReverseMap();

            CreateMap<ApplicationRoleClaim, ShowAllRoleClaimsDTO>().ReverseMap();
            CreateMap<List<ApplicationRoleClaim>, List<RoleClaimDTO>>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, ShowCategiroesDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Product, AllProductsDTO>().ReverseMap();
            CreateMap<Product, ProductsToUser>().ReverseMap();
            CreateMap<Product_Category,ProductCategoryDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>()
                .ForMember(t => t.ProductCategories,
                f => f.MapFrom(g => g.product_Categories))
                .ReverseMap();
                
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, PopularRatedProductsDTO>().ReverseMap();


            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Comment, AllCommentsDTO>().ReverseMap();

            CreateMap<ProductVote, AllProductVotesDTO>().ReverseMap();
            CreateMap<ProductVote, CreateVoteDTO>().ReverseMap();

            CreateMap<ProductRate, CreateRateDTO>().ReverseMap();
            CreateMap<ProductRate, AllProductRateDTO>().ReverseMap();
            CreateMap<Product, PopularRatedProductsDTO>().ReverseMap();
        }
    }
}
