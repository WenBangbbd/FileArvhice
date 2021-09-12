using FileArchive.AccessControl.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public interface IRoleService
    {
        Task CreateRoleAsync(Role role);
        Task<Role> GetRoleAsync(string roleCode);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task AllocateAsync(string roleCode, Authority authority);
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRep;

        public RoleService(IRoleRepository roleRep)
        {
            _roleRep = roleRep;
        }

        public async Task AllocateAsync(string roleCode, Authority authority)
        {
            var roleDto = await _roleRep.FindAsync(roleCode);
            if (roleDto == null)
                throw new ApplicationException("没有对应的角色");
            roleDto.RoleAuthorities.Add(new RoleAuthority { Authority = authority, Role = roleDto });
           await _roleRep.UpdateAsync(roleDto);
        }

        public async Task CreateRoleAsync(Role role)
        {
            var roleDto =await _roleRep.FindAsync(role.Code);
            if (roleDto != null)
                throw new ApplicationException("已存在的角色");
            await _roleRep.InsertAsync(role);
        }

        public async Task<Role> GetRoleAsync(string roleCode)
        {
            return await _roleRep.FindAsync(roleCode);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleRep.FindAllAsync();
        }
    }
}
