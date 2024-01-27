using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

        Console.WriteLine("Simple iteration with for loop");
        for (int i = 0; i < numbers.Length; i++)
        {
            int current = numbers[i];
            Console.WriteLine(current);
        }

        Console.WriteLine("\nIterating backwards");
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            int current = numbers[i];
            Console.WriteLine(current);
        }

        Console.WriteLine("\nSkipping elements");
        for (int i = 1; i < numbers.Length; i += 2)
        {
            int current = numbers[i];
            Console.WriteLine(current);
        }

        Console.WriteLine("\nUsing foreach");
        Console.WriteLine("Note that it's simpler to write and 'current' is provided immediately");
        foreach (int current in numbers)
        {
            Console.WriteLine(current);
        }
    }
}
