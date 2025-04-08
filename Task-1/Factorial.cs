using System;


class Factorial{

    static void Main(string[] args){
        int res=1;
        Console.Write("Enter a number: ");
        int n=Convert.ToInt32(Console.ReadLine());
        int i;

        if (n>0){
            for (i=n;i>0;i--){
                    res=res*i;

            }
            Console.WriteLine($"Factorial of {n} : "+ res);
        }
        else{
            Console.WriteLine("Invalid number");
        }
        
    }

}
