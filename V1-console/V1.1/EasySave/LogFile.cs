using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace EasySave
{
    class DataLogs
    {
        //Declaration of the properties that are used for the program log file
        protected string filePath = @"C:\Users\MSI GAMER\Documents\GitHub\CESIProgSys-EasySave\V1-console\V1.1\EasySave\Log.json";
        
        public string BackupDate { get; set; }       
        public string TransactionTime { get; set; }
        public long TotalSize { get; set; }
        public string name { get; set; }
        public string sourceFilePath { get; set; }
        public string targetFilePath { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public string time { get; set; }


        //nnnnn

    }
}