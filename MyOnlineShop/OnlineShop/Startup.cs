using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.DataBase;
using System;
using OnlineShop.ExtentionMethods;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.Infrastructor.Repositories;
using OnlineShop.IOC.IServices;
using OnlineShop.IOC.Services;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<OnlineShopContext>
                (options => { options.UseSqlServer("Password=ABC1%@Jbry5;Persist Security Info=True;User ID=sa;Initial Catalog=OnlineShopDB;Data Source=DESKTOP-LJMRBHR\\ENTERPRISE2019"); });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<OnlineShopContext>();

            services.AddServices();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineShop", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineShop v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
