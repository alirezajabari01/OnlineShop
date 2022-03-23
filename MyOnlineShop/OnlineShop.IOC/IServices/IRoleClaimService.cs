using OnlineShop.Core.DTO.GenericDTO;
using OnlineShop.Core.DTO.RoleClaimsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IRoleClaimService
    {
        Task<GridResultDTO<ShowAllRoleClaimsDTO>> GetAllRoleClaimsAsync(string id);
        Task<string> CreateRoleClaimAsync(RoleClaimDTO roleClaimDTO);
        Task<string> UpdateRoleClaimAsync(UpdateRoleClaimDTO updateRoleClaimDTO);
        Task<RoleClaimDTO> GetRoleClaimById(string id);
    }
}
