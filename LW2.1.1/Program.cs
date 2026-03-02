using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
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
        
        List<string> uniqueValuesList = new List<string>();

        foreach (var dict in inputData)
        {
            foreach (var value in dict.Values)
            {
                if (!uniqueValuesList.Contains(value))
                {
                    uniqueValuesList.Add(value);
                }
            }
        }
        
        Console.WriteLine("UniqueValues: {'" + string.Join("', '", uniqueValuesList) + "'}");
        
        var finalDictionary = new Dictionary<string, List<string>>
        {
            { "UniqueValues", uniqueValuesList }
        };
        
        SaveToJson(finalDictionary, "unique_results.json");

        Console.WriteLine("\nГотово! Результат збережено у файл 'unique_results.json'.");
        Console.ReadKey();
    }

    static void SaveToJson(object data, string fileName)
    {
        try
        {
            var options = new JsonSerializerOptions 
            { 
                WriteIndented = true 
            };
            
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(fileName, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при записі JSON: {ex.Message}");
        }
    }
}