using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bussiness_layer;
using Data_layer.Entities;
using Data_layer.Interfaces;

namespace Dataa_layer
{
    public class Operations
    {
        public Operations() { }
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
        public static void DeleteEntity(Human data,int index, Human[] list)//        ?????????????
        {
            if(new FileInfo(filePath).Length > 0)
            {
                var toDelete = Convert.ToString(data);
                var oldFile = System.IO.File.ReadAllLines(filePath);
                var cleanedFile = oldFile.Where(line => !line.Contains(toDelete));
                System.IO.File.WriteAllLines(filePath, cleanedFile);
                FileStream obj = new FileStream(filePath, FileMode.Append);
                obj.Close();
            }
            else
            {
                throw new Exception("List is empty");
            }
            
        }
        public static void ClearList()
        {
            using FileStream sw = File.Open("SourceFile.txt", FileMode.Open);
            sw.SetLength(0);
        }
    }
}
