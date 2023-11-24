using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer
{
    public class Operations
    {
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "SourceFile.txt";

        public static string Read()
        {
            string data;
            using (FileStream sourceFile = new (filePath, FileMode.Open, FileAccess.Read))
            {
                using StreamReader reader = new(sourceFile);
                data = reader.ReadToEnd();
            }
            return data;
        }
        public static void Write(string data)
        {
            using FileStream toFile = new (filePath, FileMode.Open, FileAccess.Write);
            using StreamWriter writer = new (toFile);
            writer.Write(data);
        }
    }
}
