int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
string top = "";
for (int i = 0; i < numbers.Length; i++)
{
    bool istopInteger = true;
    for (int j = i+1; j < numbers.Length; j++)
    {
        if (numbers[i] < numbers[j])
        {   
            istopInteger = false;
            break;
        }
    }       
    if(!istopInteger)
    {
        continue;
    }
    else
    {
        top += numbers[i] + " ";

    }
     
}
Console.WriteLine(top);
