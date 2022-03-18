using OnlineShop.Core.DTO;
using OnlineShop.Core.DTO.UsersDTO;
using OnlineShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IUserService
    {
        Task<List<ShowAllUsersDTO>> GetAllAsync();
        Task<bool> IsUserNameExistAsync(string username);
        Task<bool> IsPhoneNumberExistAsync(string phonenmber);
        Task<ShowAllUsersDTO> GetUserByIdAsync(string id);
        Task<string> CreateUserAsync(UserDTO userDTO);
        Task<string> UpdateUserAsync(UserDTO userDTO);
        Task<string> DeActiveUserAsync(string userId);
        Task<string> AddRoleToUserAsync(AddRoleToUserDTO AddroletouserDTO);
        Task<bool> RemoveRoleFromUserAsync(string id);
    }
}
