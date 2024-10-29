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

    public void Push(int value)
    {
        if (_top >= _size - 1)
        {
            Console.WriteLine("Стек переполнен!");
            return;
        }
        _array[++_top] = value;
    }

    public int Pop()
    {
        if (IsStackEmpty())
        {
            Console.WriteLine("Стек пуст! Невозможно извлечь элемент.");
            throw new InvalidOperationException("Стек пуст");
        }
        return _array[_top--];
    }

    public int Top()
    {
        if (IsStackEmpty())
        {
            Console.WriteLine("Стек пуст! Невозможно получить верхний элемент.");
            throw new InvalidOperationException("Стек пуст");
        }
        return _array[_top];
    }

    public bool IsStackEmpty()
    {
        return _top < 0;
    }

    public int Size()
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

        stack.Push(1);
        stack.Push(2);
        stack.Push(30);
        stack.Push(50);

        Console.WriteLine("Размер стека: " + stack.Size());
        Console.WriteLine("Верхний элемент: " + stack.Top());
        Console.WriteLine("Извлекаем элемент: " + stack.Pop());
        Console.WriteLine("Размер стека после извлечения: " + stack.Size());
        Console.WriteLine("Стек пуст? " + stack.IsStackEmpty());
    }
}
