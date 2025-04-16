using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clinic_Management_System.Services
{
    public static class JsonFileHandler
    {
        public static async Task SaveAsync<T>(string filePath, List<T> data)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(data, options);
                await File.WriteAllTextAsync(filePath, json);
                //Console.WriteLine(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public static async Task<List<T>> LoadAsync<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return new List<T>();

                string json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
