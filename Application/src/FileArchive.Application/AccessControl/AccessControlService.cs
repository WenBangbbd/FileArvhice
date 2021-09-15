using AutoMapper;
using FileArchive.AccessControl;
using FileArchive.AccessControl.Abstract;
using FileArchive.AccessControl.Activate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IAuthorityService _authorityService;
        private readonly IAccountActivateService _activateService;
        public AccessControlService(IMapper mapper, IUserService userService, IRoleService roleService, IAuthorityService authorityService, IAccountActivateService activateService)
        {
            _mapper = mapper;
            _userService = userService;
            _roleService = roleService;
            _authorityService = authorityService;
            _activateService = activateService;
        }

        public async Task AllocateAuthorityAsync(string roleCode, string authorityCode)
        {
            var au = await _authorityService.GetAuthorityAsync(authorityCode);
            if (au == null)
                throw new ApplicationException("未找到对应的权限");
            await _roleService.AllocateAsync(roleCode, au);
        }

        public async Task AllocateRoleAsync(string accountNo, string roleCode)
        {
            var role = await _roleService.GetRoleAsync(roleCode);
            if (role == null)
                throw new ApplicationException("未找到对应的角色");
            await _userService.AllocateAsync(accountNo, role);
        }

        public async Task CreateAuthorityAsync(AuthorityInput input)
        {
            var authrity = _mapper.Map<Authority>(input);
            await _authorityService.CreateAsync(authrity);
        }

        public async Task CreateRoleAsync(RoleInput roleInfo)
        {
            var role = _mapper.Map<Role>(roleInfo);
            await _roleService.CreateRoleAsync(role);
        }

        public async Task CreateUserAsync(UserInput userInfo)
        {
            if (userInfo.Password != userInfo.ConfirmedPassword)
                throw new ApplicationException("两次输入密码不一致");
            var user = _mapper.Map<User>(userInfo);
            await _userService.CreateAsync(user);
            var activateCode = Guid.NewGuid().ToString("n");
            await _activateService.SendActivateCodeAsync(activateCode,userInfo);
        }

        public async Task<IEnumerable<IAuthority>> GetAuthoritiesAsync()
        {
            var aus = await _authorityService.GetAuthoritiesAsync();
            return _mapper.Map<IEnumerable<AuthorityOutput>>(aus);
        }

        public async Task<IEnumerable<IRole>> GetRolesAsync()
        {
            var roles = await _roleService.GetRolesAsync();
            return _mapper.Map<IEnumerable<RoleOutput>>(roles);
        }

        public async Task<IUser> GetUserAsync(string accountNo)
        {
            return await _userService.GetUserAsync(accountNo);
        }

        public async Task<IUser> GetUserByNameAsync(string userName)
        {
            return await _userService.GetUserByAsync(userName);
        }

        public async Task<IEnumerable<UserOutput>> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserOutput>>(users);
        }

        public Task ModifyPasswordAsync(string accountNo, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task UserActivateAsync(string userName, string activateCode)
        {
           await _activateService.ActivateAsync(userName, activateCode);
        }
    }


}
