using System;
using System.Collections.Generic;
using System.IO;
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

        public void WriteTextFile(string filename, string text)
        {
            File.WriteAllText(filename, "v0.0");
        }

        public string ReadTextFile(string filename)
        {
            return File.ReadAllText(filename);
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
    }
}
