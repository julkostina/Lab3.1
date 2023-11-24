using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dataa_layer
{
    public class Operations
    {
        public Operations() { }
        private static  string filePath = AppDomain.CurrentDomain.BaseDirectory + "SourceFile.txt";

        public static string Read()
        {
            using (StreamReader sourceFile = new (filePath, System.Text.Encoding.Default))
            {
                return sourceFile.ReadToEnd();
            }
        }
        public static void Write(string data)
        {
            using (StreamWriter file = new StreamWriter(filePath, true, System.Text.Encoding.Default))
            {
                file.Write(data);
            }
        }
        public static void Clear()
        {
            File.WriteAllText(filePath, String.Empty);
        }
    }
}
