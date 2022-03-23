using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Core.DTO.GenericDTO;
using OnlineShop.Core.DTO.RoleClaimsDTO;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class RoleClaimService : IRoleClaimService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IRepository<ApplicationRoleClaim> roleRepository;
        private readonly IMapper mapper;

        public RoleClaimService(RoleManager<ApplicationRole> roleManager,
            IRepository<ApplicationRoleClaim> roleRepository,
            IMapper mapper)
        {
            this.roleManager = roleManager;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        public async Task<string> CreateRoleClaimAsync(RoleClaimDTO roleClaimDTO)
        {
            var outPut = "انجام نشد";
            var role = await roleManager.FindByIdAsync(roleClaimDTO.RoleId);

            var addroleclaimResult = await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.AuthorizationDecision, roleClaimDTO.ClaimValue));
            if (addroleclaimResult.Succeeded)
            {
                outPut = "انجام شد";
            }

            return outPut;
        }

        public async Task<GridResultDTO<ShowAllRoleClaimsDTO>> GetAllRoleClaimsAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var roleClaims = await roleManager.GetClaimsAsync(role);

            var mappedResult = new List<ShowAllRoleClaimsDTO>();

            foreach (var claim in roleClaims)
            {
                var dto = new ShowAllRoleClaimsDTO
                {
                    ClaimValue = claim.ValueType,
                    RoleId = role.Id,
                };
                mappedResult.Add(dto);
            }
            return new GridResultDTO<ShowAllRoleClaimsDTO>(mappedResult.Count, mappedResult);
        }

        public async Task<RoleClaimDTO> GetRoleClaimById(string id)
        {
            var roleClaim = await roleRepository.GetByIdAsync(id);

            return mapper.Map<RoleClaimDTO>(roleClaim);
        }

        public async Task<string> UpdateRoleClaimAsync(UpdateRoleClaimDTO updateRoleClaimDTO)
        {
            string outPut = "انجام نشد";

            var roleClaim = await roleRepository.GetByIdAsync(updateRoleClaimDTO.Id);
            if(roleClaim != null)
            {
                roleClaim.RoleId = updateRoleClaimDTO.RoleId;
                roleClaim.ClaimValue = updateRoleClaimDTO.ClaimValue;

                int updateResult = await roleRepository.UpdateAsync(roleClaim);
                if (updateResult == 1)
                {
                    outPut = "انجام شد";
                }
            }

            return outPut;
        }
    }
}
