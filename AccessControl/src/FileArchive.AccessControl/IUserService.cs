using FileArchive.AccessControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task AllocateAsync(string accountNo, Role role);
        Task<IUser> GetUserAsync(string accountNo);
        Task<IEnumerable<IUser>> GetUsersAsync();
        Task<IUser> GetUserByAsync(string userName);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRep;

        public UserService(IUserRepository userRep)
        {
            _userRep = userRep;
        }

        public async Task AllocateAsync(string accountNo, Role role)
        {
            var userDto = await _userRep.FindAsync(accountNo);
            userDto.RoleUsers.Add(RoleUser.CreateRoleUser(userDto, role));
            await _userRep.UpdateAsync(userDto);
        }

        public async Task CreateAsync(User user)
        {
            var user1 = await _userRep.FindByNameAsync(user.Name);
            if (user1 != null)
                throw new ApplicationException("用户名已存在");
            await _userRep.InsertAsync(user);
        }

        public async Task<IUser> GetUserAsync(string accountNo)
        {
            return await _userRep.FindAsync(accountNo);
        }


        public async Task<IEnumerable<IUser>> GetUsersAsync()
        {
            return await _userRep.FindAllAsync();
        }

        public async Task<IUser> GetUserByAsync(string userName)
        {
            return await _userRep.FindByNameAsync(userName);
        }
    }
}
