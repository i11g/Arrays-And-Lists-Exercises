List<int> numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToList();

List<int> condensed = new List<int>() {};


while (numbers.Count >=1)
{
   new List<int>(numbers.Count - 1); 

  for (int i = 0; i < numbers.Count/2; i++)
    {   
         numbers[i] = numbers[i] + numbers[i + 1];                       
    }
    numbers = condensed;
}
Console.WriteLine(string.Join(" ", numbers));