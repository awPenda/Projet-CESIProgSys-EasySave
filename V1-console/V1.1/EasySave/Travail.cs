﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;
using System.Linq;

namespace EasySave
{
    class Travail : Etat
    {
        public Travail()
        {}
        public Travail(string theName, string therepS, string therepC, string theType)
        {
            name = theName;
            repS = therepS;
            repC = therepC;
            type = theType;
        }
        private string name { get; set; }
        private string repS { get; set; }
        private string repC { get; set; }
        private string type { get; set; }
        public void addWork(long filesize, int countfile)
        {
            var jsonData = File.ReadAllText(filePath);
            Console.WriteLine($"state.json path {filePath}");
            var stateList = JsonConvert.DeserializeObject<List<Etat>>(jsonData) ?? new List<Etat>();

            if (stateList.Count < 5)
            {
                stateList.Add(new Etat()
                {
                    Name = name,
                    SourceFilePath = repS,
                    TargetFilePath = repC,
                    Type = type,
                    State = "INACTIVE",
                    TotalFilesToCopy = countfile.ToString(),
                    TotalFilesSize = filesize.ToString(),
                    NbFilesLeftToDo = "0",
                    Progression = "0"
                });

                string strResultJson = JsonConvert.SerializeObject(stateList);
                File.WriteAllText(filePath, strResultJson);

                Console.WriteLine("Travail ajouté avec succès !\n");
            }
            else
            {
                Console.WriteLine("Nombre maximal de travaux atteint\n");
            }
        }
        public void displayWorks()
        {

            var jsonData = File.ReadAllText(filePath);
            var stateList = JsonConvert.DeserializeObject<List<Etat>>(jsonData) ?? new List<Etat>();

            var dt = new ConsoleTable("index", "Name", "SourceFilePath", "TargetFilePath", "Type", "State", "TotalFilesToCopy", "TotalFilesSize", "NbFilesLeftToDo", "Progression");
            foreach (var (state, i) in stateList.Select((el, i) => (el, i)))
            {
                dt.AddRow(i + 1, state.Name, state.SourceFilePath, state.TargetFilePath, state.Type, state.State, state.TotalFilesToCopy, state.TotalFilesSize, state.NbFilesLeftToDo, state.Progression);
            }

            dt.Write();

        }
        static void SaveFilesFunction(string sourceFile, string targetFile)
        {
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
                // Delete source files that were copied (maybe that can be interesting ?)
                /*
                foreach (string f in fileList){
                    File.Delete(f);
                }
                foreach (string f in fileList){
                    File.Delete(f);
                }
                */
            }
            //if there's any error display it
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }

        }
public void UpdateLogFile(string inputUtilisateur)//Function to allow modification of the log file
        {
            var jsonData = File.ReadAllText(filePath);
            var loglist = JsonConvert.DeserializeObject<List<DataLogs>>(jsonData) ?? new List<DataLogs>();
            string sourceDir = loglist.ElementAt(Convert.ToInt32(inputUtilisateur) ).sourceFilePath;
            string backupDir = loglist.ElementAt(Convert.ToInt32(inputUtilisateur) ).targetFilePath;

            //Formatting the stopwatch for better visibility in the file
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}");
            DataLogs datalogs = new DataLogs //Apply the retrieved values ​​to their classes
            {
                name = name,
                sourceFilePath = repS,
                targetFilePath = repC,
                type = type,
                state = "ACTIVE",
                time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                TotalSize = TotalSize,
                //TransactionTime = elapsedTime
            };
            loglist.Add(new DataLogs()
            {
                name = name,
                sourceFilePath = repS,
                targetFilePath = repC,
                type = type,
                state = "end",

                TotalSize = TotalSize,
                TransactionTime = this.BackupDate,
                time = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"),

            });
            string strResultJson = JsonConvert.SerializeObject(loglist);
            File.WriteAllText(filePath, strResultJson);
            

            string path = System.Environment.CurrentDirectory; //Allows you to retrieve the path of the program environment
            var directory = System.IO.Path.GetDirectoryName(path); // This file saves in the project: \EasySaveApp\bin

            string serializeObj = JsonConvert.SerializeObject(datalogs, Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.AppendAllText(directory + @"DailyLogs_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json", serializeObj); //Function to write to log file

            
            Stopwatch stopwatch = new Stopwatch();
      
            File.WriteAllText(filePath, strResultJson);

            Console.WriteLine("Travail ajouté avec succès !\n");
        }
        public void ExecuteWork(int inputUtilisateur)
        {
            var jsonData = File.ReadAllText(filePath);

            var stateList = JsonConvert.DeserializeObject<List<Etat>>(jsonData) ?? new List<Etat>();


            if (stateList.Count >= inputUtilisateur)
            {
                string sourceDir = stateList.ElementAt(inputUtilisateur - 1).SourceFilePath;
                string backupDir = stateList.ElementAt(inputUtilisateur - 1).TargetFilePath;

                if (stateList.ElementAt(inputUtilisateur - 1).Type == "Différentielle")
                {
                    Console.WriteLine("Comming soon!");
                }
                else
                {
                    SaveFilesFunction(sourceDir, backupDir);
                    Console.WriteLine("Files copied!");
                }

            }
            else
            {
                Console.WriteLine("Aucun travail de sauvegarde avec l'entrée " + inputUtilisateur + " trouvée\n");
            }

            /*   try
               {
                   string[] txtList = Directory.GetFiles(sourceDir);

                   // Copy text files.
                   foreach (string f in txtList)
                   {

                       // Remove path from the file name.
                       string fName = f.Substring(sourceDir.Length + 1);

                       // Will not overwrite if the destination file already exists.
                       File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                   }
               }

               catch (DirectoryNotFoundException dirNotFound)
               {
                   Console.WriteLine(dirNotFound.Message);
               }
               DirectoryCopy(sourceDir, backupDir, true);
               static void DirectoryCopy(string src, string dest, bool copySubDir)
               {
                   // Get the subdirectories for the specified directory.
                   DirectoryInfo dir = new DirectoryInfo(src);

                   if (!dir.Exists)
                   {
                       throw new DirectoryNotFoundException(
                           "Source directory does not exist or could not be found: "
                           + src);
                   }

                   DirectoryInfo[] dirs = dir.GetDirectories();

                   // If the destination directory doesn't exist, create it.       
                   Directory.CreateDirectory(dest);

                   // Get the files in the directory and copy them to the new location.
                   FileInfo[] files = dir.GetFiles();
                   foreach (FileInfo file in files)
                   {
                       string tempPath = Path.Combine(dest, file.Name);
                       file.CopyTo(tempPath, true);
                   }

                   // If copying subdirectories, copy them and their contents to new location.
                   if (copySubDir)
                   {
                       foreach (DirectoryInfo subdir in dirs)
                       {
                           string tempPath = Path.Combine(dest, subdir.Name);
                           DirectoryCopy(subdir.FullName, tempPath, copySubDir);
                       }
                   }
               } */
        }
        public long GetFileSizeSumFromDirectory(string searchDirectory)
        {
            var files = Directory.EnumerateFiles(searchDirectory);

            // get the sizeof all files in the current directory
            var currentSize = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();

            var directories = Directory.EnumerateDirectories(searchDirectory);

            // get the size of all files in all subdirectories
            var subDirSize = (from directory in directories select GetFileSizeSumFromDirectory(directory)).Sum();

            return currentSize + subDirSize;
        }
    }
}
