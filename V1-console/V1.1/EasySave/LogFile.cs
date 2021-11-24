using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace EasySave
{
    class DataLogs
    {
        //Declaration of the properties that are used for the program log file
       
        public string BackupDate { get; set; }
       
        public string TransactionTime { get; set; }
        public long TotalSize { get; set; }
        public string name { get; set; }
        public string sourceFilePath { get; set; }
        public string targetFilePath { get; set; }
        public string type { get; set; }
        public string state { get; set; }


        //nnnnn

    }
}