using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Task7
{
    static async Task<string> FetchFromSourceAsync(string sourceName, int delay)
    {
        await Task.Delay(delay); // Simulates network delay
        return $"{sourceName} data fetched after {delay} ms";
    }

    // Simulates a failing API call
    static async Task<string> FetchFromSourceWithErrorAsync(string sourceName, int delay)
    {
        await Task.Delay(delay);
        throw new Exception($"{sourceName} failed to fetch data.");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting async data fetch...");

        // 1. Start multiple async tasks
        var tasks = new List<Task<string>>
        {
            FetchFromSourceAsync("Source A", 2000),
            FetchFromSourceAsync("Source B", 3000),
            FetchFromSourceAsync("Source C", 1500),
            FetchFromSourceWithErrorAsync("Source D", 1000) // Simulates a failure
        };

        try
        {
            // 2. Await all tasks concurrently
            string[] results = await Task.WhenAll(tasks);

            // 3. Aggregate and print results
            Console.WriteLine("\nAll sources fetched successfully:");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            // 4. Handle exception from any task
            Console.WriteLine($"\nAn error occurred: {ex.Message}");

            // Optional: Check which tasks failed/succeeded
            foreach (var task in tasks)
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine($"Task error: {task.Exception?.InnerException?.Message}");
                }
                else if (task.IsCompletedSuccessfully)
                {
                    Console.WriteLine($"Completed result: {task.Result}");
                }
            }
        }



    }


  
}
