using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public class RoleUser
    {
        public RoleUser()
        {
            CreateDateTime = DateTime.Now;
            ModifyDateTime = CreateDateTime;
        }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public static RoleUser CreateRoleUser(User user,Role role)
        {
            return new RoleUser
            {
                User = user,
                Role = role,
            };
        }
    }
}
