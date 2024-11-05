using System;

public class Stack
{
    private int[] _array;
    private int _top;
    private int _size;

    public Stack(int size)
    {
        _size = size;
        _array = new int[size];
        _top = -1; // Изначально стек пуст
    }

    public bool Push(int value)
    {
        if (_top >= _size - 1)
        {
            return false;
        }
        _array[++_top] = value;
        return true;
    }

    public bool Pop(out int value)
    {
        if (IsStackEmpty())
        {
            value = 0;
            return false;
        }
        value = _array[_top--];
        return true;
    }

    public bool Top(out int value)
    {
        if (IsStackEmpty())
        {
            value = 0;
            return false;
        }
        value = _array[_top];
        return true;
    }

    public bool IsStackEmpty()
    {
        return _top < 0;
    }

    public int GetStackSize()
    {
        return _top + 1; // Размер стека
    }

    public static Stack CreateStack(int size)
    {
        return new Stack(size);
    }
}

public class Program
{
    public static void Main()
    {
        Stack stack = Stack.CreateStack(5);
        int result;

        stack.Push(1);
        stack.Push(2);
        stack.Push(30);
        stack.Push(50);

        Console.WriteLine("Размер стека: " + stack.GetStackSize());

        if (stack.Top(out result))
        {
            Console.WriteLine("Верхний элемент: " + result);
        }
        else
        {
            Console.WriteLine("Стек пуст! Невозможно получить верхний элемент.");
        }

        if (stack.Pop(out result))
        {
            Console.WriteLine("Извлекаем элемент: " + result);
        }
        else
        {
            Console.WriteLine("Стек пуст! Невозможно извлечь элемент.");
        }

        Console.WriteLine("Размер стека после извлечения: " + stack.GetStackSize());
        Console.WriteLine("Стек пуст? " + stack.IsStackEmpty());
    }
}
