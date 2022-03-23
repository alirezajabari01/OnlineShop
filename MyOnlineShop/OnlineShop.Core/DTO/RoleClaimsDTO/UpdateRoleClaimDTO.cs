using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.RoleClaimsDTO
{
    public class UpdateRoleClaimDTO
    {
        public string RoleId { get; set; }
        public string ClaimValue { get; set; }
        public int Id { get; set; }
    }
}
