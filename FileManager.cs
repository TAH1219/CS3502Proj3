using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;

namespace CS3502Proj3
{
    public class FileManager
    {
        public IEnumerable<FileSystemInfo> GetEntries(string path)
        {
            var directoryInfo = new DirectoryInfo(path);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                yield return directory;
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                yield return file;
            }
        }

        public void CreateFile(string filePath, string fileContent)
        {
            if (File.Exists(filePath))
            {
                throw new IOException("File already exists");
            }

            File.WriteAllText(filePath, fileContent ?? string.Empty);
        }

        public void CreateDirectory(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                throw new IOException("Directory already exists");
            }

            Directory.CreateDirectory(filePath);
        }

        public void Update(string filePath, string fileContent)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            File.WriteAllText(filePath, fileContent ?? string.Empty);
        }

        public string Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            return File.ReadAllText(filePath);
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
            else
            {
                throw new FileNotFoundException("File or directory not found.", filePath);
            }
        }

        public string Rename(string pathOne, string pathTwo)
        {
            var parent = Path.GetDirectoryName(pathOne);
            var newPath = Path.Combine(parent ?? string.Empty, pathTwo);


            if (!File.Exists(pathOne) && !Directory.Exists(pathOne))
            {
                throw new FileNotFoundException("File or directory not found.", pathOne);
            }

            if (File.Exists(newPath) || Directory.Exists(newPath))
            {
                throw new IOException("File or Directory with this name already exists");
            }

            if (File.Exists(pathOne))
            {
                File.Move(pathOne, newPath);
            }
            else
            {
                Directory.Move(pathOne, newPath);
            }

            return newPath;
        }
    }
}


 









    

