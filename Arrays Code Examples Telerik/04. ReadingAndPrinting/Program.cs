using System;

class Program
{
    static void Main()
    {
        // First read number of lines, 
        // then read a number from each next line
        Console.Write("Number of lines = ");
        int numberOfLines = int.Parse(Console.ReadLine());
        int[] numbers = new int[numberOfLines];

        for (int i = 0; i < numberOfLines; i++)
        {
            Console.Write("Next number = ");
            int nextNumber = int.Parse(Console.ReadLine());
            numbers[i] = nextNumber;
        }

        // Now we can print the results
        Console.WriteLine("Done!");
        Console.WriteLine($"Read a total of {numberOfLines} lines");
        for (int i = 0; i < numberOfLines; i++)
        {
            int current = numbers[i];
            Console.WriteLine($"At line {i + 1} the number was {current}");
        }
    }
}
