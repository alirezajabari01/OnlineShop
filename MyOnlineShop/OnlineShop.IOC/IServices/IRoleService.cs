using OnlineShop.Core.DTO.RolesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IRoleService
    {
        Task<List<ShowAllRolesDTO>> GetAllRoles();
        Task<RoleDTO> GetRoleById(string id);
        Task<string> DeActiveRole(string id);
        Task<string> CreateRole(RoleDTO roleDTO);
        Task<string> UpdateRole(RoleDTO roleDTO);
    }
}
