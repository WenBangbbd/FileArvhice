using System.Collections.Generic;

namespace FileArchive.AccessControl.Abstract

{
    public class UserOutput : IUser
    {
        public string Name { get; set; }
        public string TelePhoneNo { get; set; }
        public IEnumerable<IRole> Roles { get; set; }
    }
}
