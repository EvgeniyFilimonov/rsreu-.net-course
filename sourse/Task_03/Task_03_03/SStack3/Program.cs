using System;
using System.Collections.Generic;

public class RPNCalculator
{
    public static double Evaluate(string expression)
    {
        Stack<double> stack = new Stack<double>(); 

        string[] tokens = expression.Split(' ');

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number); 
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(a + b); 
                        break;
                    case "-":
                        stack.Push(a - b); 
                        break;
                    case "*":
                        stack.Push(a * b); 
                        break;
                    case "/":
                        stack.Push(a / b); 
                        break;
                    default:
                        throw new InvalidOperationException($"Неизвестный оператор: {token}"); 
                }
            }
        }

        return stack.Pop();
    }

    public static void Main()
    {
        Console.WriteLine("Введите выражение в ОПН (например, '1 2 3 * +'):");
        string input = Console.ReadLine();

        try
        {
            double result = Evaluate(input); 
            Console.WriteLine($"Результат: {result}"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}"); 
        }
    }
}
