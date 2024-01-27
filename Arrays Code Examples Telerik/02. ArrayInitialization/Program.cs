using System;

class Program
{
    static void Main()
    {
        // create an int array that can hold 10 numbers
        // all slots have default value 0
        int[] numbers = new int[10];

        // create a string array that can hold 5 strings
        // all slots have default value 'null'
        string[] names = new string[5];

        // assign values to the 'numbers' array
        // array indices 0-9 will have values 1-10 after the loop is over
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        // create and initialize an array of strings
        // C# knows that the array has a length of 4, 
        // because we create it with that many elements
        string[] seasons = { "Winter", "Spring", "Summer", "Autumn" };
        foreach (var season in seasons)
        {
            Console.WriteLine(season);
        }
    }
}
