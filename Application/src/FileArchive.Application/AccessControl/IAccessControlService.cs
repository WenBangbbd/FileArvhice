using FileArchive.AccessControl;
using FileArchive.AccessControl.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public interface IAccessControlService
    {
        Task CreateUserAsync(UserInput userInfo);
        Task<IUser> GetUserAsync(string accountNo);
        Task ModifyPasswordAsync(string accountNo, string oldPassword, string newPassword);
        Task CreateRoleAsync(RoleInput roleInfo);
        Task AllocateRoleAsync(string accountNo, string roleCode);
        Task<IEnumerable<IRole>> GetRolesAsync();
        Task<IEnumerable<UserOutput>> GetUsersAsync();
        Task CreateAuthorityAsync(AuthorityInput input);
        Task<IEnumerable<IAuthority>> GetAuthoritiesAsync();
        Task AllocateAuthorityAsync(string code, string authorityCode);
        Task<IUser> GetUserByNameAsync(string userName);
        Task UserActivateAsync(string userName, string activateCode);
    }


}
