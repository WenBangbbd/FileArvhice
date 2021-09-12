using System;
using System.IO;

namespace FileArchive.FileService.Abstract
{
    public interface IFileArchiveInfo
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string NameWithExtension => UUId+"."+Extension;
        /// <summary>
        /// 有相对路径的名称
        /// </summary>
        public string UUIDWithSubPath =>SubPath+@"\"+UUId;
        /// <summary>
        /// 创建时间        
        /// </summary>
        public DateTime CreateDateTime { get;}
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime  ModifyDateTime { get;}
        /// <summary>
        /// 唯一识别码
        /// </summary>
        public string UUId { get; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get;  }
        /// <summary>
        /// 子路径，必须
        /// </summary>
        public string SubPath { get; }
    }
}
