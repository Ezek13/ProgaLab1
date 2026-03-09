using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var inputData = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { {"V", "S001"} },
            new Dictionary<string, string> { {"V", "S002"} },
            new Dictionary<string, string> { {"VI", "S001"} },
            new Dictionary<string, string> { {"VI", "S005"} },
            new Dictionary<string, string> { {"VII", "S005"} },
            new Dictionary<string, string> { {"V", "S009"} },
            new Dictionary<string, string> { {"VIII", "S007"} }
        };

        var uniqueValuesList = inputData
            .SelectMany(dict => dict.Values)
            .Distinct()
            .ToList();

        Console.WriteLine($"Знайдено унікальних значень: {uniqueValuesList.Count}");
        
        var finalDictionary = new Dictionary<string, List<string>>
        {
            { "UniqueValues", uniqueValuesList }
        };
        
        string fileName = "unique_results.json";
        SaveToJson(finalDictionary, fileName);

        string fullPath = Path.GetFullPath(fileName);
        Console.WriteLine($"\nГотово! Файл збережено за шляхом:\n{fullPath}");
        
        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }

    static void SaveToJson(object data, string fileName)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(fileName, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при записі JSON: {ex.Message}");
        }
    }
}