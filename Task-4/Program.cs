using System;
using System.Collections.Generic;
using System.Linq;

namespace task4
{

    class Student
    {
        public string name;
        public int age;
        public int grade;

        public Student(string Name,int Age,int Grade) { 
            
            name = Name;
            age = Age;
            grade = Grade;
        
        }
        public override string ToString()
        {
            return $"Name: {name}, Age: {age}, Grade: {grade}";
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                List<Student> students = new List<Student>
                {
                    new Student("Arun", 20, 90),
                    new Student("Balaji",25,65),
                    new Student("ram",25,77),
                    new Student("kumar",15,57),
                    new Student("mike",21,40)
                };

                //Console.WriteLine(list);

                //using Arrow Functions
                var studentData = students.Where(s => s.grade > 70);

                Console.WriteLine("Using Arrow functions");
                foreach (var k in studentData)
                {
                    Console.WriteLine(k);
                }

                //using query syntax
                Console.WriteLine("\n");
                Console.WriteLine("Using Query");
                var studentData2 = from s in students
                                   where s.grade > 50
                                   orderby s.age
                                   select s;

                foreach (var j in studentData2)
                {
                    Console.WriteLine(j);
                }

            }
                
            
            
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
         
        }
    }
}