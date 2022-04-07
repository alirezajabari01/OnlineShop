using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.DataBase;
using System;

namespace OnlineShop.ConfigurationServices
{
    public static class IdentityServices
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>
         (o =>
         {
             o.Password.RequiredLength = 4;

         }).AddEntityFrameworkStores<OnlineShopContext>().AddDefaultTokenProviders();

        }
    }
}
