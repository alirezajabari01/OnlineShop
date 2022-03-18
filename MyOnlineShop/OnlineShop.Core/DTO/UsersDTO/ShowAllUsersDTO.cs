using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO
{
    public class ShowAllUsersDTO
    {
        public string Id { get; set; } 
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
