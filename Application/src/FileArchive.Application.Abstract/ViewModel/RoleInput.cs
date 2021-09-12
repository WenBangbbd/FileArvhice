using System.Collections.Generic;

namespace FileArchive.AccessControl.Abstract

{
    public class RoleInput
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    public class AuthorityInput
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    public class AuthorityOutput:IAuthority
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
