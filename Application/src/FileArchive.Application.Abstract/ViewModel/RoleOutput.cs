using System.Collections.Generic;

namespace FileArchive.AccessControl.Abstract

{
    public class RoleOutput : IRole
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public IEnumerable<IAuthority> Authorities { get; set; }
    }
}
