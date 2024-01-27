using System;

class Program
{
    static void Main()
    {
        // Аrray Initialization
        string[] daysOfWeek = new string[]
        {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
        };

        // Print first element
        Console.WriteLine(daysOfWeek[0]);

        // Print last element
        int lastIndex = daysOfWeek.Length - 1;
        Console.WriteLine(daysOfWeek[lastIndex]);

        // Change element at index
        daysOfWeek[0] = "Monday is my favourite day";
        Console.WriteLine(daysOfWeek[0]);

        // Get the number of available array slots
        Console.WriteLine(daysOfWeek.Length);
    }
}
