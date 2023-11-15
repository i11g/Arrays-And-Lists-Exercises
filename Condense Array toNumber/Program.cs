int [] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); 

int[] condensed=new int[numbers.Length-1];
if(numbers.Length ==1)
{
    Console.WriteLine(numbers[0]);
}

while (condensed.Length > 0)
{
    condensed = new int[numbers.Length - 1];
    for (int i = 0; i<numbers.Length-1; i++)
    {
        condensed[i] = numbers[i] + numbers[i+1];
    }
    numbers = condensed;
    if (condensed.Length ==1)
    {
        Console.WriteLine(string.Join(" ", condensed));
    }
}
