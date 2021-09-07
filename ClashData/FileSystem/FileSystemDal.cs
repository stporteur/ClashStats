using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashData.FileSystem
{
    public class FileSystemDal : IFileSystemDal
    {
        public bool DoesFileExist(string filename)
        {
            return File.Exists(filename);
        }

        public void CreateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public void CleanFolder(string folder)
        {
            var files = Directory.GetFiles(folder);
            foreach(var file in files)
            {
                File.Delete(file);
            }

            var subFolders = Directory.GetDirectories(folder);

            foreach (var subFolder in subFolders)
            {
                CleanFolder(subFolder);
                Directory.Delete(subFolder);
            }
        }

        public void WriteTextFile(string filename, string text)
        {
            File.WriteAllText(filename, text);
        }

        public string ReadTextFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        public byte[] ReadAllBytes(string filename)
        {
            return File.ReadAllBytes(filename);
        }

        public List<string> ReadTextFileByLines(string filename)
        {
            return File.ReadAllLines(filename).ToList();
        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public List<string> GetSubDirectories(string folder)
        {
            return Directory.GetDirectories(folder).Select(x => new DirectoryInfo(x).Name).ToList();
        }

        public List<string> GetFiles(string folder)
        {
            return Directory.GetFiles(folder).ToList();
        }

        public void DeleteFolder(string folder)
        {
            Directory.Delete(folder);
        }

        public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
        }

        public void ExtractToDirectory(string zipFile, string destinationFolder)
        {
            ZipFile.ExtractToDirectory(zipFile, destinationFolder);
        }
    }
}
