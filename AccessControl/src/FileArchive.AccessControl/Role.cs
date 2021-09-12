using FileArchive.AccessControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileArchive.AccessControl
{
    public class Role : IRole
    {
        public Role()
        {
            CreateDateTime = DateTime.Now;
            ModifyDateTime = CreateDateTime;
            RoleAuthorities = new List<RoleAuthority>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<RoleUser> RoleUsers { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public List<RoleAuthority> RoleAuthorities { get; set; }
        public IEnumerable<IAuthority> Authorities => RoleAuthorities?.Select(r => r.Authority);

    }
}
