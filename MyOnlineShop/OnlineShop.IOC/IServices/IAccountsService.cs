using OnlineShop.Core.DTO.UsersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IAccountsService
    {
        Task<string> CheckUserNameAsync(string userName);
        Task<string> CheckPhoneNmberAsync(string phoneNumber);
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task<string> RegisterAsync(RegisterDTO registerDTO);
    }
}
