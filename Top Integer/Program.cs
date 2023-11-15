string input = Console.ReadLine();
string[] numberStrings = input.Split(' ').Select;

int[] numbers = new int[numberStrings.Length];

int max = int.MinValue;
string top = "";

for (int i = 0; i < numbers.Length; i++)
{
    if (numbersStrings[i] > max)
    {
        max = numberStrings[i];
        top = numbers[i] + " ";
    }
    else if (numbers[i] == max)
    {
        top += numbers[i] + " ";
    }
}

Console.WriteLine(top);
