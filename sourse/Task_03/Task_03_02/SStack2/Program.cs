using System;
using System.Collections.Generic;
using System.Diagnostics;

public class StockPriceDiffWithoutStack
{
    // Метод для вычисления максимальной разницы цен
    public static int CalculateMaxDifference(int[] prices)
    {
        int maxDiff = 0; 
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                int diff = prices[j] - prices[i]; 
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }
        }
        return maxDiff; 
    }
}

public class StockPriceDiffWithStack
{
    // Метод для вычисления максимальной разницы цен
    public static int CalculateMaxDifference(int[] prices)
    {
        Stack<int> stack = new Stack<int>(); // Создаем стек для хранения цен
        int maxDiff = 0; 

        foreach (int price in prices)
        {
            while (stack.Count > 0 && price <= stack.Peek())
            {
                stack.Pop(); 
            }
            if (stack.Count > 0)
            {
                maxDiff = Math.Max(maxDiff, price - stack.Peek()); // Обновляем максимальную разницу
            }
            stack.Push(price); // Добавляем текущую цену в стек
        }
        return maxDiff; 
    }
}

public class Program
{
    public static void Main()
    {
        int[] prices = new int[10000]; 
        Random random = new Random(); 

        for (int i = 0; i < prices.Length; i++)
        {
            prices[i] = random.Next(1, 1000); 
        }

        // Измерение времени выполнения алгоритма без стека
        var stopwatch = Stopwatch.StartNew(); // Запускаем таймер
        int differenceWithoutStack = StockPriceDiffWithoutStack.CalculateMaxDifference(prices);
        stopwatch.Stop(); // Останавливаем таймер
        Console.WriteLine($"Разница (без стека): {differenceWithoutStack}, время: {stopwatch.ElapsedMilliseconds} мс");

        // Измерение времени выполнения алгоритма со стеком
        stopwatch.Restart(); // Перезапускаем таймер
        int differenceWithStack = StockPriceDiffWithStack.CalculateMaxDifference(prices);
        stopwatch.Stop(); // Останавливаем таймер
        Console.WriteLine($"Разница (со стеком): {differenceWithStack}, время: {stopwatch.ElapsedMilliseconds} мс");
    }
}
