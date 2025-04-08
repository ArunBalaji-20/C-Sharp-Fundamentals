using System;

class Persons{
        string Name;
        int age;

        public Persons(string cName,int cAge){
            Name=cName;
            age=cAge;
        }
        public void Introduce(){
            Console.WriteLine($"Welcome {Name}, How are you?");
        }
    static void Main(string[] args){
        // Console.WriteLine("hellooo");
        Persons myobj1=new Persons("Arun",20);
        myobj1.Introduce();

        Persons myobj2=new Persons("Balaji",22);
        myobj2.Introduce();

        Persons myobj3=new Persons("kumar",17);
        myobj3.Introduce();
    }
}