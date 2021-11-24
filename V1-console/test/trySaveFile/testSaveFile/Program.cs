using System;

//add that for the save thing! 
using System.IO;

namespace testSaveFile
{
    class DirectoryCopyExample
    {
        static void Main()
        {
            //the source file and target file, remplace it by yours (im not sure but i think i've taken the same var names than you)
            string sourceFile = @"C:\Users\ameli\Documents\GitHub\CESIProgSys-EasySave\files\sourceFile";
            string targetFile = @"C:\Users\ameli\Documents\GitHub\CESIProgSys-EasySave\files\targetFile";

            SaveFilesFunction(sourceFile, targetFile);

        }


        static void SaveFilesFunction(string sourceFile, string targetFile)
        {
            //the source file and target file, remplace it by yours (im not sure but i think i've taken the same var names than you)
            
            try
            {
                //get each files in the directory
                string[] fileList = Directory.GetFiles(sourceFile, "*");
                //for each file
                foreach (string i in fileList)
                {
                    // isolate name from the path
                    string fName = i.Substring(sourceFile.Length + 1);
                    // Use the Path.Combine method to safely append the file name to the path
                    // Will overwrite if the destination file already exists
                    // first source dir, snd target dir, last true or false for the sub dirs 
                    File.Copy(Path.Combine(sourceFile, fName), Path.Combine(targetFile, fName), true);
                }
                // Delete source files that were copied
                foreach (string f in fileList)
                {
                    File.Delete(f);
                }
                foreach (string f in fileList)
                {
                    File.Delete(f);
                }
            }
            //if there's any error display it
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }

        }

    }

    
}