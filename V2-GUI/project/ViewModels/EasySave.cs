using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace test2
{

    class EasySave
    {
        private static EasySave instance = null;
        public static EasySave Getinstance()
        {
            if (instance == null)
            {
                instance = new EasySave();
            }
            return instance;
        }



        public List<FullBackup> fullBackups = new List<FullBackup>();
        public List<DifferentialBackup> Diffbck = new List<DifferentialBackup>();
        // a method that will allow to create a backupwork
        public void addWork(long filesize, int countfile, string theName, string theRepS, string theRepC, string theType)
        {




            //LIT dans WORK.JSON
            var jsonDataWork = File.ReadAllText(Work.filePath); //Read the JSON file
            var workList = JsonConvert.DeserializeObject<List<Work>>(jsonDataWork) ?? new List<Work>(); //convert a string into an object for JSON


            //LIT dans STATE.JSON
            var jsonDataWork2 = File.ReadAllText(Etat.filePath); //Read the JSON file
            var stateList = JsonConvert.DeserializeObject<List<Etat>>(jsonDataWork2) ?? new List<Etat>();







            bool nameExist = false;
            for (int i = 0; i < stateList.Count; i++)
            {
                if (stateList[i].Name == theName)
                {
                    nameExist = true;
                    break;
                }
                else
                {
                    nameExist = false;
                }
            }

            if (!nameExist)
            {
                workList.Add(new Work() //parameter that the JSON file will contains
                {
                    name = theName,
                    repS = theRepS,
                    repC = theRepC,
                    type = theType,
                });








                //ECRIT DANS WORK.JSON
                string strResultJsonWork = JsonConvert.SerializeObject(workList, Formatting.Indented);  //convert an object into a string for JSON
                File.WriteAllText(Work.filePath, strResultJsonWork); // write in the JSON file

                //LIT DANS STATE.JSON
                var jsonDataState2 = File.ReadAllText(Etat.filePath); //Read the JSON file
                var stateList2 = JsonConvert.DeserializeObject<List<Etat>>(jsonDataState2) ?? new List<Etat>(); //convert a string into an object for JSON







                stateList2.Add(new Etat() //parameter that the JSON file will contains
                {
                    Name = theName,
                    SourceFilePath = theRepC,
                    TargetFilePath = theRepS,
                    Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    State = "INACTIVE",
                    TotalFilesToCopy = countfile.ToString(),
                    TotalFilesSize = filesize.ToString(),
                    NbFilesLeftToDo = "0",
                    Progression = "0%"
                });





                //ECRIT DANS STATE.JSON
                string strResultJsonState = JsonConvert.SerializeObject(stateList2, Formatting.Indented); //convert an object into a string for JSON
                File.WriteAllText(Etat.filePath, strResultJsonState); // write in the JSON file







                // Switch the language of the outpoot according to the choice of the user when he started the program

              
               
            }
            else
            {   // Switch the language of the outpoot according to the choice of the user when he started the program
                
                
            }
        }
        public string name = "";
        public string Name { get => name; set => name = value; }
        public string Valuer_recup { get => valuer_recup; set => valuer_recup = value; }
        private string valuer_recup;
        public List<Work> displayWorks() // a method that will allow to display all our backupwork
        {



            var jsonData = File.ReadAllText(Work.filePath); //Read the JSON file
            var stateList = JsonConvert.DeserializeObject<List<Work>>(jsonData) ?? new List<Work>();





            return stateList;
        }







        public void ExecuteWork(string inputUtilisateur) // a method that will allow to execute a backupwork created
        {
            if (Process.GetProcessesByName("Calculator").Length == 0)
            {
            var j = File.ReadAllText(Settings.filePath2); //Read the JSON setting file
            var met = JsonConvert.DeserializeObject<List<Settings>>(j) ?? new List<Settings>(); //convert a string into an object for JSON

            string Metier = Convert.ToString(met[0].logiciel);

            

                var jsonData = File.ReadAllText(Work.filePath); //Read the JSON Work file
                var workList = JsonConvert.DeserializeObject<List<Work>>(jsonData) ?? new List<Work>(); //convert a string into an object for JSON

                if (workList.Count >= Convert.ToInt32(inputUtilisateur)) //this condition allow to the user to choose the exact row in order to execute the backupwork chosen
                {
                    int index = Convert.ToInt32(inputUtilisateur) - 1;
                    string sourceDir = workList.ElementAt(index).repS;
                    string backupDir = workList.ElementAt(index).repC;
                    Name = workList.ElementAt(index).name;

                    long filesNum = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories).Length;

                    //this condition is used to execute the type of backup chosen in the creation 

                    if (workList.ElementAt(Convert.ToInt32(inputUtilisateur) - 1).type == "Differential")
                    {

                        var jsonDataState2 = File.ReadAllText(Etat.filePath); //Read the JSON State file
                        var stateList2 = JsonConvert.DeserializeObject<List<Etat>>(jsonDataState2) ?? new List<Etat>();

                        int indexState = 0;
                        for (int i = 0; i < stateList2.Count; i++)
                        {
                            if (stateList2[i].Name == workList[index].name)
                            {
                                indexState = i;
                                break;
                            }
                        }

                        stateList2[indexState].State = "Active";
                        string strResultJsonState2 = JsonConvert.SerializeObject(stateList2, Formatting.Indented);

                        File.WriteAllText(Etat.filePath, strResultJsonState2);

                        // differential backup
                       
                        Diffbck.Add(new DifferentialBackup());
                        Diffbck[Diffbck.Count - 1].Sauvegarde(sourceDir, backupDir, true, indexState, filesNum, index, Name);
                        Valuer_recup = Name;

                    }
                    else
                    {

                        var jsonDataState2 = File.ReadAllText(Etat.filePath); //Read the JSON State file
                        var stateList2 = JsonConvert.DeserializeObject<List<Etat>>(jsonDataState2) ?? new List<Etat>();

                        int indexState = 0;
                        for (int i = 0; i < stateList2.Count; i++)
                        {
                            if (stateList2[i].Name == workList[index].name)
                            {
                                indexState = i;
                                break;
                            }
                        }

                        stateList2[indexState].State = "Active";
                        string strResultJsonState2 = JsonConvert.SerializeObject(stateList2, Formatting.Indented);

                        //mettre un lock   
                        File.WriteAllText(Etat.filePath, strResultJsonState2);

                        // complete backup
                        fullBackups.Add(new FullBackup());
                        fullBackups[fullBackups.Count - 1].Sauvegarde(sourceDir, backupDir, true, indexState, filesNum, index, Name);
                        Valuer_recup = Name;

                    }


                }
               
            }
            else
            {
                //mettre en pause puis lancer quand le logiciel métier est fermé
                MessageBox.Show("ImpossibleToRunBuissnessSoftwareRunning");
            }











        }

        public long GetFileSizeSumFromDirectory(string searchDirectory) //a method that allow to calculate the size of a directory (subdirrectory included)
        {
            var files = Directory.EnumerateFiles(searchDirectory);

            // get the sizeof all files in the current directory
            var currentSize = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();

            var directories = Directory.EnumerateDirectories(searchDirectory);

            // get the size of all files in all subdirectories
            var subDirSize = (from directory in directories select GetFileSizeSumFromDirectory(directory)).Sum();

            return currentSize + subDirSize;
        }
        public void SuppWork(int getIndex)
        {


            var JsonDataStateSupp = File.ReadAllText(Work.filePath);
            var Supp = JsonConvert.DeserializeObject<List<Work>>(JsonDataStateSupp) ?? new List<Work>();
            Supp.Remove(Supp[getIndex]);

            string strR = JsonConvert.SerializeObject(Supp, Formatting.Indented);  //convert an object into a string for JSON
            File.WriteAllText(Work.filePath, strR);
            MessageBox.Show("Travail supprimé");


        }






        public List<Etat_Inactive> displayState()
        {



            List<Etat_Inactive> stateList;
            List<Etat_Inactive> stateList2 = new List<Etat_Inactive>();
            lock (Locker.Read_State)
            {

                var jsonDataState2 = File.ReadAllText(Etat_Inactive.filePath); //Read the JSON State file
                stateList = JsonConvert.DeserializeObject<List<Etat_Inactive>>(jsonDataState2) ?? new List<Etat_Inactive>();
                int i = 0;
                foreach (Etat_Inactive x in stateList)
                {
                    i = i++;
                    if (x.State == "Active")
                    {
                        stateList2.Add(x);
                    }
                }

                //mettre un lock   
            }
            return stateList2;


        }

    }
}
