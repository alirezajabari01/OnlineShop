using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.DataBase
{
    public class OnlineShopContextFactory : IDesignTimeDbContextFactory<OnlineShopContext>
    {
        public OnlineShopContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OnlineShopContext>();

            builder.UseSqlServer
                ("Password=ABC1%@Jbry5;Persist Security Info=True;User ID=sa;Initial Catalog=OnlineShopDB;Data Source=DESKTOP-LJMRBHR\\ENTERPRISE2019");


            return new OnlineShopContext(builder.Options);
        }
    }
}
