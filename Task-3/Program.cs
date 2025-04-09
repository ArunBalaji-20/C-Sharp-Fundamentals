using System;
using System.Collections.Generic;
namespace task3
{

    public class Program
    {
        public List<String> names = new List<string>();


        public void addData(string n)
        {
            names.Add(n);
        }

        public void removeData(string n){
            names.Remove(n);
        }
        public void display()
        {
            foreach (String i in names)
            {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.display();

            try
            {
                bool running = true;

                while (running)
                {
                     Console.WriteLine("Choose one ....");
                    Console.WriteLine("1.Add a name to the list.");
                    Console.WriteLine("2.Remove a name from list.");
                    Console.WriteLine("3.Display list");
                    Console.WriteLine("4.Exit");
                    int inp = Convert.ToInt32(Console.ReadLine());

                    switch (inp)
                    {
                        case 1:
                            Console.WriteLine("enter a name to add:");
                            string name = Console.ReadLine();
                            name= name.Trim();
                            name=name.ToUpper();
                            obj.addData(name);
                            break;
                        case 2:
                            Console.WriteLine("enter the name to remove:");
                            name = Console.ReadLine();
                            name=name.Trim();
                            name = name.Trim();
                            name = name.ToUpper();
                            obj.removeData(name);
                            break;
                        case 3:
                            obj.display();
                            break;
                        case 4:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("invalid option");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}