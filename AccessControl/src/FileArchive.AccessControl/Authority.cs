using FileArchive.AccessControl.Abstract;
using System;
using System.Collections.Generic;

namespace FileArchive.AccessControl
{
    public class Authority : IAuthority
    {
        public int Id { get; set; }
        public string Name {get;set;}
        public string Code {get;set;}
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public IEnumerable<RoleAuthority> RoleAuthorities { get; set; }
    }
}
