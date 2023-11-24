using System;
using Data_layer;
using Bussiness_layer;
using Data_layer.Interfaces;
using Data_layer.Entities;
using Dataa_layer;
using System.Runtime.InteropServices;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace OutputProject
{
    public class ConsoleMenu
    {
        private Database db = new Database();
        private Operations operation = new Operations();
        private Human[] list = new Human[100];
        private Checking check = new Checking();
        private int num;
        private bool finish = false;
        public ConsoleMenu() { }
        private void CreateList()
        {
            Human[] l = new Human[5];
            l[0] = new Student("Katya", "Abramova", 180, 70, "907562961", "KB73026028");
            l[1] = new Librarian("Jane", "Smith", "906362961");
            l[2] = new Student("David", "Fox", 170, 60, "307572920", "KB33724028");
            l[3] = new SoftwareDeveloper("Olivia", "Fly", "907503710");
            l[4] = new Student("Harry", "Donald", 192, 82, "017562961", "KB06384028");
            for(int i = 0; i < l.Length; i++)
            {
                Database.AddPerson(l[i], ref list);
            }
        }
        public void Menu()
        {
            Operations.Clear();
            CreateList();
            while (!finish) {
                Console.Write("Enter:\n" +
                    "1. to view the collection library and simple array of vectors.\n" +
                    "2. to add new person to the database.\n" +
                    "3. to delete person from position.\n" +
                    "4. to search student by last name.\n" +
                    "5. to view students with ideal weight.\n" +
                    "6. to view activities of humans.\n"+
                    "7. to view who can cycling.\n"+
                    "8. to quit\n");
                try
                {
                    ChooseAction();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
        private void ChooseAction()
        {
            num = Convert.ToInt32(Console.ReadLine());
            bool err = false;
            switch (num)
            {
                case 1:
                    Console.Clear();
                    Console.Write(db.ToString());
                    break;
                case 2:
                    Console.Clear();
                    CreateEntity();
                    break;
                case 3:
                    Console.Clear();
                    int index = 0;
                    for (int i = 0; i < list.Length - 1; i++)
                    {
                        if (list[i] != null)
                        {
                            index++;
                        }
                    }
                    for (int i = 0; i < index; i++)
                    {
                        Console.Write(i);
                        if (list[i] is Student)
                        {
                            Student st = (Student)list[i];
                            Console.WriteLine(". Student" + " " + st.Name + " " + st.Surname + "\n{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"" + st.Name + "\",\r\n    \"lastName\": \"" + st.Surname + "\",\r\n    \"height\": \"" + st.Height + "\",\r\n    \"weight\": \"" + st.Weight + "\",\r\n    \"stCard\": \"" + st.StudentCard + "\"\r\n    \"passport\": \"" + st.Passport + "\"\r\n\n}");
                        }
                        if (list[i] is Librarian)
                        {
                            Console.WriteLine(". Librarian" + " " + list[i].Name + " " + list[i].Surname + "\n{\r\n    \"entity\": \"librarian\",\r\n    \"firstName\": \"" + list[i].Name + "\",\r\n    \"lastName\": \"" + list[i].Surname + "\"\r\n     \"passport\": \"" + list[i].Passport + "\"\r\n\n}");
                        }
                        if (list[i] is SoftwareDeveloper)
                        {
                            Console.WriteLine(". Software developer" + " " + list[i].Name + " " + list[i].Surname + "\n{\r\n    \"entity\": \"software developer\",\r\n    \"firstName\": \"" + list[i].Name + "\",\r\n    \"lastName\": \"" + list[i].Surname + "\",\r\n    \"passport\": \"" + list[i].Passport + "\"\r\n\n}");
                        }
                    }
                    do
                    {
                        err = false;
                        try
                        {
                            Console.WriteLine("Enter index: ");
                            if (!int.TryParse(Console.ReadLine(), out index) || (index < Database.Size(ref list) - 1 && index > Database.Size(ref list) - 1))
                                throw new("Incorrect index\n");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            err = true;
                        }
                    } while (err==true);
                    Database.DeletePerson(list[index], index, ref list);
                    break;
                case 4:
                    int num = 0;
                    Console.Clear();
                    string lastName = CreateNameSurname("surname");
                    if (Database.SearchByLastName(lastName, ref list, out num) == true)
                    {
                        Console.WriteLine($"\nStudent found on {num} postion.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nSuch student wasn`t found.\n");
                    }
                    break;
                case 5:
                    Console.Clear();
                    Student[] stList = Database.StudentsWithIdealWeight(ref list);
                    int n = 0;
                    if (stList.Length != 0)
                    {
                        for (int i = 0; i < stList.Length; i++)
                        {
                            if (stList[i] != null)
                            {
                                Console.WriteLine(i + ". " + stList[i].Name + " " + stList[i].Surname + "\n{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"" + stList[i].Name + "\",\r\n    \"lastName\": \"" + stList[i].Surname + "\",\r\n    \"height\": \"" + stList[i].Height + "\",\r\n    \"weight\": \"" + stList[i].Weight + "\",\r\n    \"stCard\": \"" + stList[i].StudentCard + "\"\r\n    \"passport\": \"" + stList[i].Passport + "\"\r\n}");
                                n++;
                            }

                        }
                        Console.WriteLine($"There are {n} students with ideal weight.\n\n");
                    }
                    else
                    {
                        throw new("List is empty");
                    }
                    break;
                case 6:
                    Console.Clear();
                    for(int i=0;i<Database.Size(ref list); i++)
                    {
                        string entity = "";
                        if (list[i] is Student)
                        {
                            entity = "Student";
                        }
                        if  (list[i] is Librarian)
                        {
                            entity = "Librarian";
                        }
                        if (list[i] is SoftwareDeveloper)
                        {
                            entity = "Software developer";
                        }
                        Console.WriteLine($"{entity} {list[i].Name} {list[i].Surname}:\n\r{list[i].Activity()}\n");
                    }
                    break;
                case 7:
                    Console.Clear();
                    for (int i = 0; i < Database.Size(ref list); i++)
                    {
                        string entity = "";
                        if (list[i] is Student)
                        {
                            entity = "Student";
                        }
                        if (list[i] is Librarian)
                        {
                            entity = "Librarian";
                        }
                        if (list[i] is SoftwareDeveloper)
                        {
                            entity = "Software developer";
                        }
                        Console.WriteLine($"{entity} {list[i].Name} {list[i].Surname}:\n\r{list[i].Cycling()}\n");
                    }
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Program completed successful!");
                    finish = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
        }
        private void CreateEntity()
        {
            bool err = false;
            string name = "";
            string surname = "";
            string passport = "";
            do
            {
                Console.WriteLine("Enter:" +
            "\r\n1. to create student" +
            "\r\n2. to create librarian" +
            "\r\n3. to create software developer");
                try
                {
                    int person = Convert.ToInt32(Console.ReadLine());
                    switch (person)
                    {
                        case 1:
                            err = false;
                            CreatePerson(out name, out surname, out passport);
                            Database.AddPerson(new Student(name, surname, CreateWeightHeight("height"), CreateWeightHeight("weight"), passport, CreateStCard()), ref list);
                            Console.Clear();
                            Console.WriteLine("Student added!\n");
                            break;

                        case 2:
                            err = false;
                            CreatePerson(out name, out surname, out passport);
                            Database.AddPerson(new Librarian(name, surname, passport), ref list);
                            Console.Clear();
                            Console.WriteLine("Librarian added!\n");
                            break;
                        case 3:
                            err = false;
                            CreatePerson(out name, out surname, out passport);
                            Database.AddPerson(new SoftwareDeveloper(name, surname, passport), ref list);
                            Console.Clear();
                            Console.WriteLine("Software developer added!\n");
                            break;
                        default:
                            err = true;
                            throw new Exception("Unknown entity!");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            
        }
        private void CreatePerson(out string name, out string surname, out string passport)
        {
            name = CreateNameSurname("name");
            surname = CreateNameSurname("surname");
            passport = CreatePassport();

        }
        private string CreateNameSurname( string checkValue)
        {
            string input="";
            bool err = false;
            string res="";
            do
            {
                try
                {
                    Console.WriteLine($"Enter {checkValue}: ");
                    input = Console.ReadLine();
                    if (!check.validNameSurname.IsMatch(input))
                    {
                        err = true;
                        throw new Exception($"Invalid {checkValue}!");
                    }
                    res = input;
                    err = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        private string CreatePassport()
        {
            string input = "";
            bool err = false;
            string res = "";
            do
            {
                try
                {
                    Console.WriteLine("Enter pasport: ");
                    input = Console.ReadLine();
                    if (!check.validPassport.IsMatch(input))
                    {
                        err = true;
                        throw new Exception("Invalid passport!");
                    }
                    res = input;
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        private string CreateStCard()
        {
            string input = "";
            bool err = false;
            string res = "";
            do
            {
                try
                {
                    Console.WriteLine("Enter student card in format KB12345678: ");
                    input = Console.ReadLine();
                    if (!check.validStCard.IsMatch(input))
                    {
                        err = true;
                        throw new Exception("Invalid student card!");
                    }
                    res = input;
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        private int CreateWeightHeight( string checkValue)
        {
            int input=0;
            bool err = false;
            int res=0;
            do
            {
                try
                {
                    Console.WriteLine($"Enter {checkValue}: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (!check.validWeightHeight.IsMatch(Convert.ToString(input)))
                    {
                        err = true;
                        throw new Exception($"Invalid {checkValue}!");
                    }
                    res = Convert.ToInt32(input);
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
    }
}
