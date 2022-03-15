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
        Task<List<ApplicationUser>> GetAll();
        Task<bool> IsUserNameExist(string username);
        Task<bool> IsPhoneNumberExist(string phonenmber);
        Task<ApplicationUser> GetUserById(string id);
    }
}
