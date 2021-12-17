using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace test2
{
    //a backup interface that contains the definition of the backup method (abstract factory interface )
    interface IBackup
    {
        void Sauvegarde(string sourcePATH, string destPATH, bool copyDirs, int getStateIndex, long fileCount, int getIndex, string getName);
    }
}
