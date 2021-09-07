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
        void CleanFolder(string folder);
        byte[] ReadAllBytes(string physicalfilePath);

        List<string> GetFiles(string folder);
        void DeleteFolder(string folder);
        void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName);
        void ExtractToDirectory(string zipFile, string destinationFolder);
    }
}