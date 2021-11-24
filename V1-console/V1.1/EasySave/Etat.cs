using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave
{
    class Etat
    {
        protected string filePath = @"C:\Users\ameli\Documents\GitHub\CESIProgSys-EasySave\V1-console\V1.1\EasySave\state.json";

        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string TotalFilesToCopy { get; set; }
        public string TotalFilesSize { get; set; }
        public string NbFilesLeftToDo { get; set; }
        public string Progression { get; set; }
    }
}