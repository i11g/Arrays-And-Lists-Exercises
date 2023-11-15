int[] num=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

string result ="";

for (int i = 0; i < num.Length/2; i++)
{
    int res = num[i] + num[num.Length - 1 - i];
    result+= res+" ";

}
    if(num.Length%2!=0)
    {
        result+= (num.Length/2+1).ToString();
    }

Console.WriteLine(result);
