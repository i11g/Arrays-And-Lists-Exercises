int[] num=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

int[] condensed = new int[num.Length - 1];
if(num.Length ==1 )
{
    Console.WriteLine(num[0]);
}

while (condensed.Length > 0)
{
    condensed = new int[num.Length - 1];
    for (int i = 0; i < num.Length-1; i++)
    {
        condensed[i] =num[i]+ num[i+1];
    }
     num=condensed;
    if(condensed.Length == 1 )
    {
        Console.WriteLine(string.Join(" ", condensed));
    }
}
