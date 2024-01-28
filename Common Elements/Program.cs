int[] num1=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
int[] num2=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

string elements ="";
for (int i = 0; i < num1.Length; i++)
{
    for (int j = 0; j < num2.Length; j++)
    {
        if (num1[i] == num2[j])
        {
            elements += num1[i] + " ";
        }
    }
}
Console.WriteLine(elements);
