using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using SeleniumFramework.util;

namespace SeleniumProject.src.main.core.utils
{
    class FileHandler
    {
        private static readonly string downloadPath = TestDataManager.GetInstance.GetDownloadPath();

        public static void WaitForDownload(string fileName)
        {
            var filePath = Path.Combine(downloadPath, fileName);
            var timeout = TimeSpan.FromMinutes(1);
            var startTime = DateTime.Now;

            while (DateTime.Now - startTime < timeout)
            {
                if (File.Exists(filePath))
                {
                    return;
                }

                Thread.Sleep(1000);
            }

            throw new TimeoutException($"File {fileName} did not download within the timeout.");
        }

        public static string ReadFile(string fileName)
        {
            var filePath = Path.Combine(downloadPath, fileName);
            return File.ReadAllText(filePath, Encoding.UTF8);
        }

        public void RenameFile(string oldName, string newName)
        {
            var oldFilePath = Path.Combine(downloadPath, oldName);
            var newFilePath = Path.Combine(downloadPath, newName);
            File.Move(oldFilePath, newFilePath);
        }

        public static HashSet<string> ListFiles(string dir)
        {
            var files = new HashSet<string>();

            foreach (var file in Directory.EnumerateFiles(dir))
            {
                files.Add(Path.GetFileName(file));
            }

            return files;
        }

        public static void DeleteFiles(string path)
        {
            var files = ListFiles(path);
            foreach (var file in files)
            {
                var filePath = Path.Combine(path, file);
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
