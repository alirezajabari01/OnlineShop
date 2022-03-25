using AutoMapper;
using OnlineShop.Core.DTO;
using OnlineShop.Core.DTO.CategoriesDTO;
using OnlineShop.Core.DTO.RoleClaimsDTO;
using OnlineShop.Core.DTO.RolesDTO;
using OnlineShop.Core.DTO.UsersDTO;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Domain.Entities.Products;
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
            CreateMap<Category,ShowCategiroesDTO>().ReverseMap();
        }
    }
}
