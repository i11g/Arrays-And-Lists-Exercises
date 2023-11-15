int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

int result = 0;
string resultAll ="";
for (int i = 0; i < numbers.Length / 2; i++)
{
    result = numbers[i] + numbers[numbers.Length - 1 - i];
    resultAll += result + " ";
}
if (numbers.Length % 2 != 0)
{
    resultAll += (numbers.Length / 2) +1;
}
Console.WriteLine(resultAll);