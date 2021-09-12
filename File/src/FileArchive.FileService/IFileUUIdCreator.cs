using System;

namespace FileArchive.FileService
{
    public interface IFileUUIdCreator
    {
        string Create();
    }
    public class FileUUIdCreator : IFileUUIdCreator
    {
        public string Create()
        {
            return Guid.NewGuid().ToString("n");
        }
    }
}
