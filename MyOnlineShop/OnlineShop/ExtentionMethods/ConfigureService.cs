using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Core.Security.Users;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.DataBase;
using OnlineShop.Infrastructor.Repositories;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using OnlineShop.IOC.Mapper;
using OnlineShop.IOC.Services;

namespace OnlineShop.ExtentionMethods
{
    public static class ConfigureService
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountsService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IRoleClaimService, RoleClaimService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<ICategoyService, CategoyService>();

        }
    }
}
