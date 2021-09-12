using System;
using System.Collections.Generic;

namespace FileArchive.AccessControl
{
    public class RoleAuthority
    {
        public RoleAuthority()
        {
            CreateDateTime = DateTime.Now;
            ModifyDateTime = CreateDateTime;
        }
        public Authority Authority { get;  set; }
        public int AuthorityId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
       
    }
}
