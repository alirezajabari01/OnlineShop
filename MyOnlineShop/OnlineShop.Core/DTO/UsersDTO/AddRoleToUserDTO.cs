using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.UsersDTO
{
    public class AddRoleToUserDTO
    {
        public IEnumerable<string> RoleId { get; set; }
        public string UserId { get; set; }
    }
}
