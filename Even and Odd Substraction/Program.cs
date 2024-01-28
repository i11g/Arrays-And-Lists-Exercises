int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
int sumOdd = 0;
int sumEven = 0;

for(int i = 0; i < numbers.Length; i++)
{
    if (numbers[i]%2 == 0)
    {
        sumEven += numbers[i];
    }
    else
    {
        sumOdd += numbers[i];
    }
}
Console.WriteLine(sumEven-sumOdd);
