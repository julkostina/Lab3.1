using Data_layer.Interfaces;
using Data_layer.Entities;
using System;
using System.Collections.Generic;
using Dataa_layer;
using System.Runtime.CompilerServices;

namespace Bussiness_layer
{
    public class Database
    {
        public Database() { }
        private readonly string file = "SourseFile.txt";
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "SourceFile.txt";
        private static Operations o = new();
        private static Human[] l = new Human[100];
        public static int Size(ref Human[] list)
        {

            int size = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    size++;
                }
            }
            return size;

        }
        public static bool SearchByLastName(string lastName, ref Human[] list, out int index)
        {
            index = 0;
            bool res = false;

            for (int i = 0; i < Size(ref list); i++)
            {
                if (lastName == list[i].Surname) { res = true; index = i; }

            }
            return res;
        }

        public static void DeletePerson(Human data, int index, ref Human[] list)
        {
            string[] lines = data.ToString().Split("\r\n");
           foreach (string line in lines)
            {
                var toDelete = line;
                var oldFile =System.IO.File.ReadAllLines(filePath);
                var cleanedFile = oldFile.Where(line => !line.Contains(toDelete));
                System.IO.File.WriteAllLines(filePath, cleanedFile);
            }
            FileStream obj = new FileStream(filePath, FileMode.Append);
            obj.Close();
            if (list != null)
            {
                for (int i = index; i < Size(ref list); i++)
                {
                    list[i] = list[i + 1];
                }
            }
        }

        public static void AddPerson(Human human, ref Human[] list)
        {
            int i = 0;
            while (list[i] != null) { i++; }
            list[i] = human;

            if (human is Student)
            {
                Student st = (Student)human;
                Operations.Write("  Student" + " " + st.Name + " " + st.Surname + "\n{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"" + st.Name + "\",\r\n    \"lastName\": \"" + st.Surname + "\",\r\n    \"height\": \"" + st.Height + "\",\r\n    \"weight\": \"" + st.Weight + "\",\r\n    \"stCard\": \"" + st.StudentCard + "\",\r\n    \"passport\": \"" + human.Passport + "\"\n}\n\n");
            }
            if (human is Librarian)
            {
                Operations.Write(" Librarian" + " " + human.Name + " " + human.Surname + "\n{\r\n    \"entity\": \"librarian\",\r\n    \"firstName\": \"" + human.Name + "\",\r\n    \"lastName\": \"" + human.Surname + "\",\r\n     \"passport\": \"" + human.Passport + "\"\n}\n\n");
            }
            if (human is SoftwareDeveloper)
            {
                Operations.Write(" Software developer" + " " + human.Name + " " + human.Surname + "\n{\r\n    \"entity\": \"software developer\",\r\n    \"firstName\": \"" + human.Name + "\",\r\n    \"lastName\": \"" + human.Surname + "\",\r\n    \"passport\": \"" + human.Passport + "\"\n}\n\n");
            }
        }

        public static Student[] StudentsWithIdealWeight(ref Human[] list)
        {
            Student[] res = new Student[100];
            int j = 0;
            for (int i = 0; i < Size(ref list); i++)
            {
                if (list[i] is Student)
                {
                    Student student = (Student)list[i];
                    if ((student.Height - 110) == student.Weight)
                    {
                        res[j] = student;
                        j++;
                    }
                }
            }
            return res;
        }
        public override string ToString()
        {
            return Operations.Read();
        }

    }
}