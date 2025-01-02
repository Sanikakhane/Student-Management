using System.IO;
using System.Text.Json;
using StudentManagementSystem.Models;


namespace StudentManagementSystem.Services
{
    public static class JsonHelper
    {
        public static List<T> LoadJsonData<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"The file is not found at {filePath}");

                var jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON data: {ex.Message}");
                return new List<T>();
            }
        }

        public static void SaveJsonData<T>(List<T> data, string filePath)
        {
            
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"The file is not found at {filePath}");

                var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in saving the JSON data {ex.Message}");
            }
        }

    }

}
