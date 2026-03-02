using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string filePath = "D:\\Project.c#\\LW2.1\\LW2.1\\text.txt";

        
        ReadFile(filePath);
        
        Console.ReadKey();
    }

    static void ReadFile(string path)
    {
        try
        {
            string content = File.ReadAllText(path);
            
            List<char> charList = new List<char>(content);

            Console.WriteLine($"Файл прочитано. Символів у списку: {charList.Count}");
            
            CountLetters(charList);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
        }
    }

    static void CountLetters(List<char> characters)
    {
        string vowelsSet = "аеєиіїоуюяАЕЄИІЇОУЮЯ";
        
        int vowelsCount = 0;
        int consonantsCount = 0;

        foreach (char c in characters)
        {
            if (char.IsLetter(c))
            {
                if (vowelsSet.Contains(c))
                {
                    vowelsCount++;
                }
                else
                {
                    consonantsCount++;
                }
            }
        }

        Console.WriteLine("--- Результати аналізу ---");
        Console.WriteLine($"Кількість голосних: {vowelsCount}");
        Console.WriteLine($"Кількість приголосних: {consonantsCount}");
    }
}