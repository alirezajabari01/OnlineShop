using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Security.Users
{
    public interface IUserContext
    {
        public string UserId { get; set; }
    }
}
