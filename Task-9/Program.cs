using System;
using System.Linq;
using System.Reflection;

// ---------- Custom Attribute ----------
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
}

// ---------- Classes with Runnable Methods ----------
public class TaskA
{
    [Runnable]
    public static void Run()
    {
        Console.WriteLine("TaskA is running...");
    }
}

public class TaskB
{
    [Runnable]
    public static void Execute()
    {
        Console.WriteLine("TaskB is executing...");
    }

    public static void NotRunnable()
    {
        Console.WriteLine("This should NOT be called.");
    }
}

public class TaskC
{
    [Runnable]
    public static void Process()
    {
        Console.WriteLine("TaskC is processing...");
    }
}

// ---------- Main Program ----------
class Program
{
    static void Main()
    {
        Console.WriteLine(" Discovering [Runnable] methods...\n");

        Assembly currentAssembly = Assembly.GetExecutingAssembly();

        foreach (Type type in currentAssembly.GetTypes())
        {
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (method.GetCustomAttributes(typeof(RunnableAttribute), false).Any())
                {
                    Console.WriteLine($" Invoking: {type.Name}.{method.Name}()");
                    method.Invoke(null, null); // Call the static method
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine(" Done.");
    }
}
