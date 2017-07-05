using System.Collections.Generic;
using System.IO;

namespace Beeant.Tool.Publish
{
    class Program
    {
        private static void Main(string[] args)
        {
            var paths = GetReplacePaths();
            if (paths == null)
                return;
            foreach (var path in paths)
            {
                Replace(path);
            }
   
        }
        /// <summary>
        /// 得到替换目录
        /// </summary>
        /// <returns></returns>
        private static IList<string> GetReplacePaths()
        {
            var rootPath = GetRootPath();
            var dir=new DirectoryInfo(rootPath);
            if (dir.Parent == null)
                return null;
            var subDirs = dir.Parent.GetDirectories();
            var paths=new List<string>();
            foreach (var subDir in subDirs)
            {
                if(subDir.Name.ToLower()=="publish")
                    continue;
                paths.Add(subDir.FullName);
            }
            return paths;
        }
        /// <summary>
        /// 得到文件
        /// </summary>
        /// <param name="path"></param>
        private static void Replace(string path)
        {
            var rootPath = GetRootPath();
            ReplaceFiles(string.Format(@"{0}Config", rootPath),
                string.Format(@"{0}Config", path));
            ReplaceFiles(string.Format(@"{0}Scripts", rootPath),
                string.Format(@"{0}Scripts", path));
        }

        /// <summary>
        /// 得到根目录
        /// </summary>
        /// <returns></returns>
        private static string GetRootPath()
        {
            return  Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 得到文件
        /// </summary>
        /// <param name="orgPath"></param>
        /// <param name="desPath"></param>
        private static void ReplaceFiles(string orgPath, string desPath)
        {
            if (!Directory.Exists(desPath))
               return;
            var orgDirectory=new DirectoryInfo(orgPath);
            var files = orgDirectory.GetFiles();
            foreach (var file in files)
            {
                var desFileName = string.Format(@"{0}\{1}", desPath, file.Name);
                var desFile=new FileInfo(desFileName);
                if (!desFile.Exists || file.LastWriteTime != desFile.LastWriteTime)
                    file.CopyTo(desFileName, desFile.Exists);
            }
            var directories = orgDirectory.GetDirectories();
            foreach (var directory in directories)
            {
                ReplaceFiles(string.Format(@"{0}\{1}", orgPath, directory.Name),
                    string.Format(@"{0}\{1}", desPath, directory.Name));
            }
        }
    }
}
