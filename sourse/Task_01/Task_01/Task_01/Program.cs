using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите значение n:");
        int n = int.Parse(Console.ReadLine());

        double an = Math.Pow(-1, n) / ((n + 1) * (n + 2) * (n + 3));

        Console.WriteLine($"Значение an при n = {n} равно {an}");
    }
}
