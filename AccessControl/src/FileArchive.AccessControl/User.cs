using FileArchive.AccessControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileArchive.AccessControl
{
    public class User : IUser
    {
        public User()
        {
            CreateDateTime = DateTime.Now;
            ModifyDateTime = CreateDateTime;
            RoleUsers = new List<RoleUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelePhoneNo { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string AccountNo { get; set; }
        public string Password { get; set; }
        public List<RoleUser> RoleUsers { get; set; }

        public IEnumerable<IRole> Roles => RoleUsers.Select(r => r.Role);
    }
}
