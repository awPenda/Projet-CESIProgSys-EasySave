using System;
using System.IO;

/*
namespace testSaveFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}*/

namespace testSaveFile
{
    class DirectoryCopyExample
    {
        static void Main()
        {
            // first source dir, snd target dir, last true or false for the sub dirs 

            string sourceFile = @"C:\Users\ameli\Documents\GitHub\CESIProgSys-EasySave\files\sourceFile";
            string targetFile = @"C:\Users\ameli\Documents\GitHub\CESIProgSys-EasySave\files\targetFile";

            Console.WriteLine($"sourceFile : {sourceFile},\n targetFile : {targetFile}");
            //DirectoryCopy(sourceFile, targetFile, true);

            if (!Directory.Exists(targetFile)){
                Directory.CreateDirectory(targetFile);
                Console.WriteLine($"creating {targetFile} ... ");
            }
            foreach (var srcPath in Directory.GetFiles(sourceFile)){
                //Copy the file from sourcepath and place into mentioned target path, 
                //Overwrite the file if same file is exist in target path
                //does not work but idk why 
                File.Copy(srcPath, srcPath.Replace(sourceFile, targetFile), true);
                Console.WriteLine($"srcPath : {srcPath},\n sourceFile : {sourceFile},\n targetFile : {targetFile}, \n srcPath.Replace(sourceFile, targetFile) : {srcPath.Replace(sourceFile, targetFile)}");
                Console.WriteLine($"srcPath : {srcPath},\n sourceFile : {sourceFile},\n targetFile : {targetFile}");
            }

            Console.WriteLine($"copy finished !");


        }




        /*
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);
            Console.WriteLine($"CreateDirectory...");

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }*/
    }
}