﻿using System.Collections.Generic;

namespace FileArchive.AccessControl.Abstract
{
    public interface IUser
    {
        public string Name { get; }
        public string TelePhoneNo { get; }
        public IEnumerable<IRole> Roles { get;}
    }
}
