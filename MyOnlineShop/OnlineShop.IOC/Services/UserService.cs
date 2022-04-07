using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO;
using OnlineShop.Core.DTO.UsersDTO;
using OnlineShop.Core.Security;
using OnlineShop.Core.SeedData;
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
        private readonly IMapper mapper;

        public UserService(UserManager<ApplicationUser> userManager, IRepository<ApplicationUser> repository, IMapper mapper)
        {
            _userManager = userManager;
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> AddRoleToUserAsync(AddRoleToUserDTO AddroletouserDTO)
        {
            string outPut = "انجام نشد";
            var findUserByIdResult = await _userManager.FindByIdAsync(AddroletouserDTO.UserId);
            if (findUserByIdResult != null)
            {
                await RemoveRoleFromUserAsync(AddroletouserDTO.UserId);

                var addRoleToUserResult = await _userManager.AddToRolesAsync(findUserByIdResult, AddroletouserDTO.RoleId);
                if (addRoleToUserResult.Succeeded)
                {
                    outPut = "انجام شد";
                }
            }
            return outPut;
        }

        public async Task<string> CheckPhoneNmberAsync(string phoneNumber)
        {
            string result = "";
            var user = await _userManager.Users.FirstOrDefaultAsync(s => s.PhoneNumber == phoneNumber);
            if (user != null)
            {
                result = "تلفن همراه در سامانه ثبت شده است";
            }
            return result;
        }

        public async Task<string> CheckUserNameAsync(string userName)
        {
            string result = "نام کاربری یافت نشد";
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                result = "";
            }
            return result;
        }

        public async Task<string> CreateUserAsync(UserDTO userDTO)
        {
            string outPut = "انجام نشد";

            var userMapped = mapper.Map<ApplicationUser>(userDTO);
            userMapped.EmailConfirmed = false;
            userMapped.PhoneNumberConfirmed = false;
            userMapped.TwoFactorEnabled = false;
            userMapped.IsActive = false;

            var CreatedResult = await _userManager.CreateAsync(userMapped);
            if (CreatedResult.Succeeded)
            {
                var addToRole = await _userManager.AddToRoleAsync(userMapped, "User");
                if (addToRole.Succeeded)
                {
                    outPut = "انجام شد";
                }
            }

            return outPut;
        }

        public async Task<string> DeActiveUserAsync(string userId)
        {
            string outPut = "انجام نشد";

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsActive = false;
                outPut = "انجام شد";
            }

            return outPut;
        }

        public async Task<List<ShowAllUsersDTO>> GetAllAsync()
        {
            var userS = await _userManager.Users.ToListAsync();
            return mapper.Map<List<ShowAllUsersDTO>>(userS);
        }

        public async Task<ShowAllUsersDTO> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return mapper.Map<ShowAllUsersDTO>(user);
        }

        public async Task<bool> IsPhoneNumberExistAsync(string phonenmber)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(phonenmber))
            {
                var user = await _repository.GetAll().FirstOrDefaultAsync(s => s.PhoneNumber == phonenmber);
                if (user != null)
                {
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> IsUserNameExistAsync(string username)
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

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            string token = "کاربر یافت نشد";

            string hashedPassword = HashGenerator.Salterhash(loginDTO.PasswordHash);

            var user = await _userManager.Users
                .Include(s=>s.UserRoles).ThenInclude(s=>s.Role).ThenInclude(s=>s.RoleClaims)
                .FirstOrDefaultAsync
                (u => u.UserName == loginDTO.UserName && u.PasswordHash == hashedPassword);

            if (user != null)
            {

                token = hashedPassword == user.PasswordHash ? TokenGenerator.GenerateToken(user) : "";
            }

            return token;
        }

        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            
            string outPut = "انجام نشد";
            registerDTO.PasswordHash = HashGenerator.Salterhash(registerDTO.PasswordHash);

            var dtoMapped = mapper.Map<ApplicationUser>(registerDTO);

            var registerResult = await _userManager.CreateAsync(dtoMapped);
            if (registerResult.Succeeded)
            {
                var addToRoleResult = await _userManager.AddToRoleAsync(dtoMapped, AuthorizationRole.UserRole);
                if (addToRoleResult.Succeeded)
                {   
                    outPut = TokenGenerator.GenerateToken
                        (await _userManager.FindByNameAsync(registerDTO.UserName));
                }
            }
            return outPut;
        }

        public async Task<bool> RemoveRoleFromUserAsync(string id)
        {
            bool outPut = false;

            var findUserByIdResult = await _userManager.FindByIdAsync(id);
            if (findUserByIdResult != null)
            {
                var userRoles = await _userManager.GetRolesAsync(findUserByIdResult);
                if (userRoles.Count > 0)
                {
                    foreach (var roleName in userRoles)
                    {
                        await _userManager.RemoveFromRoleAsync(findUserByIdResult, roleName);
                        outPut = true;
                    }
                }
            }

            return outPut;
        }

        public async Task<string> UpdateUserAsync(UserDTO userDTO)
        {
            string outPut = "انجام نشد";

            var user = await _userManager.FindByIdAsync(userDTO.Id);

            if (user != null)
            {
                user.PhoneNumber = userDTO.PhoneNumber;
                user.UserName = userDTO.UserName;

                var updateUser = await _userManager.UpdateAsync(user);
                if (updateUser.Succeeded)
                {
                    outPut = "انجام شد";
                }
            }

            return outPut;
        }
    }
}
