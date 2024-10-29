using System;
using System.Collections.Generic;

public class DelimiterChecker
{
    public static void CheckDelimiters(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in input)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine($"Несоответствующая закрывающая скобка: {ch}");
                    return;
                }

                char open = stack.Pop();

                if (!IsMatchingPair(open, ch))
                {
                    Console.WriteLine($"Несоответствующая пара: {open} и {ch}");
                    return;
                }
            }
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("Символы-разграничители корректны и симметричны.");
        }
        else
        {
            Console.WriteLine("Есть не закрытые открывающие скобки.");
        }
    }

    private static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }

    public static void Main()
    {
        Console.WriteLine("Введите последовательность символов-разграничителей (например, ( ) { [ ] ( ) { } }):");
        string input = Console.ReadLine(); 

        CheckDelimiters(input);
    }
}
