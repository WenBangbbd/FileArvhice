using System;

namespace FileArchive.AccessControl.Abstract
{
    public interface IAuthority
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; }
    }
}
