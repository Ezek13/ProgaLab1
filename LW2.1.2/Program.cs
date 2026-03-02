using System;
using System.Collections.Generic;
using System.Linq; 

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int D = 7; 
        List<int> A = new List<int> { -17, 7, 10, 25, 37, 42, 57, 8 };


        int result = A.Where(n => n > 0 && n % 10 == D).FirstOrDefault();
   
        
        Console.WriteLine($"Цифра D: {D}");
        Console.WriteLine($"Послідовність: {string.Join(", ", A)}");
        Console.WriteLine($"Результат: {result}");

        Console.ReadKey();
    }
}