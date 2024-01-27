using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Add several numbers, separated by a comma, e.g '1,2,3,4'");
        string inputLine = Console.ReadLine();

        // We can use string.Split('separator') 
        // It will produce an array of strings:
        string[] numbersAsString = inputLine.Split(',');

        int[] powers = new int[numbersAsString.Length];
        int index = 0;
        foreach (var numAsString in numbersAsString)
        {
            int number = int.Parse(numAsString);
            powers[index] = number * number;
            index++;
        }

        // We can now output the powers, joined by a separator
        // use the string.Join() method:
        string output = string.Join(", ", powers);
        Console.WriteLine($"Powers: {output}");
    }
}
