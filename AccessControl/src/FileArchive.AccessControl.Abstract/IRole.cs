using System.Collections.Generic;

namespace FileArchive.AccessControl.Abstract
{
    public interface IRole
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string  Name { get; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; }

        public IEnumerable<IAuthority> Authorities { get;}
    }
}
