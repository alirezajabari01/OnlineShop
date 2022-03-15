using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ApplicationUser> _repository;

        public UserService(UserManager<ApplicationUser> userManager, IRepository<ApplicationUser> repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
           return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> IsPhoneNumberExist(string phonenmber)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(phonenmber))
            {
                var user = await _repository.GetAll().FirstOrDefaultAsync(s => s.PhoneNumber == phonenmber);
                if(user != null)
                {
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> IsUserNameExist(string username)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(username))
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
