using System;
using System.Collections.Generic;
using System.Text;

namespace test2
{
    class Etat_Inactive
    {
        public static string filePath = @"..\..\..\Files\state.json";

        public string Name { get; set; }
        public string Progression { get; set; }
        public string State = "INACTIVE";
    }
}