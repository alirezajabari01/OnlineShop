using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.Repositories;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using OnlineShop.IOC.Services;

namespace OnlineShop.ExtentionMethods
{
    public static class ConfigureService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserManager<ApplicationUser>>();
        }
    }
}
