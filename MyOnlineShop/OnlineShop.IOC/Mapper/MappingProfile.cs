using AutoMapper;
using OnlineShop.Core.DTO;
using OnlineShop.Core.DTO.RolesDTO;
using OnlineShop.Domain.Entities.Identity;

namespace OnlineShop.IOC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ShowAllUsersDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();

            CreateMap<ApplicationRole, ShowAllRolesDTO>().ReverseMap();
            CreateMap<ApplicationRole, RoleDTO>().ReverseMap();
        }
    }
}
