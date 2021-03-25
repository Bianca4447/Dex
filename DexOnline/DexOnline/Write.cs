using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexOnline
{
    class Write
    {
        string fileWords = "D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt";
        public Write(string Id, string Word, string Description, string Category, string Image)
        {
            string txt = Id + "#" + Word + "#" + Description + "#" + Category + "#" + Image;

            using (StreamWriter objWriter = new StreamWriter(fileWords, true))
            {
                objWriter.WriteLine(txt);
            }
        }

    }
}

