using FileArchive.AccessControl;
using FileArchive.AccessControl.Abstract;
using FileArchive.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileArchive.WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class AccessController : ControllerBase
    {
        private readonly IAccessControlService _accessControlService;

        public AccessController(IAccessControlService accessControlService)
        {
            _accessControlService = accessControlService;
        }
        [HttpPost("User")]
        public async Task CreateUserAsync([FromBody]UserInput userInfo)
        {
            await _accessControlService.CreateUserAsync(userInfo);
        }
        [HttpGet("User/{userName}")]
        public async Task<IUser> GetUserByNameAsync(string userName)
        {
            return await _accessControlService.GetUserByNameAsync(userName);
        }
        [HttpGet("User/{userName}/{activateCode}")]
        public async Task UserActivateAsync(string userName,string activateCode)
        {
            await _accessControlService.UserActivateAsync(userName, activateCode);
        }
        //[HttpGet("User/{accountNo}")]
        //public async Task<IUser> GetUserAsync(string accountNo)
        //{
        //    return await _accessControlService.GetUserAsync(accountNo);
        //}
        [HttpGet("User")]
        public async Task<IEnumerable<IUser>> GetUsersAsync()
        {
            return await _accessControlService.GetUsersAsync();
        }
        [HttpPatch("User/{accountNo}")]
        public async Task ModifyPasswordAsync(string accountNo, string oldPassword, string newPassword)
        {
            await _accessControlService.ModifyPasswordAsync(accountNo, oldPassword, newPassword);
        }
        [HttpPost("Role")]
        public async Task CreateRoleAsync(RoleInput roleInfo)
        {
            await _accessControlService.CreateRoleAsync(roleInfo);
        }
        [HttpPost("User/{accountNo}")]
        public async Task AllocateRoleAsync(string accountNo, string roleCode)
        {
            await _accessControlService.AllocateRoleAsync(accountNo, roleCode);
        }
        [HttpGet("Role")]
        public async Task<IEnumerable<IRole>> GetRolesAsync()
        {
            return await _accessControlService.GetRolesAsync();
        }
        [HttpPost("Authority")]
        public async Task CreateAuthorityAsync(AuthorityInput input)
        {
            await _accessControlService.CreateAuthorityAsync(input);
        }
        [HttpGet("Authority")]
        public async Task<IEnumerable<IAuthority>> GetAuthoritiesAsync()
        {
            return await _accessControlService.GetAuthoritiesAsync();
        }
        [HttpPost("Role/{roleCode}")]
        public async Task AllocateAuthorityAsync(string roleCode,string authorityCode)
        {
            await _accessControlService.AllocateAuthorityAsync(roleCode, authorityCode);
        }
    }
}
