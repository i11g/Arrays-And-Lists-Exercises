int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
List<int> topIntegers = new List<int>();

for (int i = 0; i < numbers.Length; i++)
{
    bool isTopInteger = true;

    for (int j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] < numbers[j])
        {
            isTopInteger = false;
            break;
        }
    }

    if (isTopInteger)
    {
        if (!topIntegers.Contains(numbers[i]))
        {
            topIntegers.Add(numbers[i]);
        }
    }
}

Console.WriteLine(string.Join(" ", topIntegers));

