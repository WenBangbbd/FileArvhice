using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileArchive.AccessControl.Abstract

{
    public class UserInput : IUser
    {
        public string Name { get; set; }
        public string TelePhoneNo { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Password { get; set; }
        public string AccountNo { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public IEnumerable<IRole> Roles => throw new NotImplementedException();

        
    }
}
