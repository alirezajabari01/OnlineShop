using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO.RolesDTO;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IMapper mapper;

        public RoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task<string> CreateRole(RoleDTO roleDTO)
        {
            string output = "انجام نشد";

            var role = mapper.Map<ApplicationRole>(roleDTO);
            var creatResult = await roleManager.CreateAsync(role);
            if (creatResult.Succeeded)
            {
                output = "انجام شد";
            }
            return output;
        }

        public async Task<string> DeActiveRole(string id)
        {
            string outPut = "انجام نشد";
            var role = await roleManager.FindByIdAsync(id);

            role.IsActive = true;
            var resultUpdate = await roleManager.UpdateAsync(role);

            if (resultUpdate.Succeeded)
            {
                mapper.Map<RoleDTO>(role);
                outPut = "انجام شد";
            }

            return outPut;
        }

        public async Task<List<ShowAllRolesDTO>> GetAllRoles()
        {
            var roleS = await roleManager.Roles.ToListAsync();
            return mapper.Map<List<ShowAllRolesDTO>>(roleS);
        }

        public async Task<RoleDTO> GetRoleById(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return mapper.Map<RoleDTO>(role);
        }

        public async Task<string> UpdateRole(RoleDTO roleDTO)
        {
            string output = "انجام نشد";

            var RoleById = await roleManager.FindByIdAsync(roleDTO.Id);
            if (RoleById != null)
            {
                RoleById.Id = roleDTO.Id;
                RoleById.IsActive = roleDTO.IsActive;
                RoleById.Name = roleDTO.Name;
                RoleById.NormalizedName = roleDTO.Name.ToUpper();

                var updateResult = await roleManager.UpdateAsync(RoleById);
                if (updateResult.Succeeded)
                {
                    output = "انجام شد";
                }
            }
            return output;
        }
    }
}
