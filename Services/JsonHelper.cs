using System.IO;
using System.Text.Json;
using StudentManagementSystem.Models;


namespace StudentManagementSystem.Services
{
    public static class JsonHelper
    {
        public static List<T> LoadJsonData<T>(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData);
        }
        public static void SaveJsonData<T>(List<T> data, string filePath)
        {
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }

    }

}
