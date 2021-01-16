using System.Collections.Generic;

namespace ClashData.FileSystem
{
    public interface IFileSystemDal
    {
        void CreateFolder(string folder);
        bool DoesFileExist(string filename);
        string GetCurrentDirectory();
        List<string> GetSubDirectories(string folder);
        string ReadTextFile(string filename);
        List<string> ReadTextFileByLines(string filename);
        void WriteTextFile(string filename, string text);
    }
}