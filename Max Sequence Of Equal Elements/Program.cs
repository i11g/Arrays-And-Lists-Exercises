List<int> numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToList();
List <int> sequence=new List<int>();
int maxSequence = 0;
List<int> max=new List<int>();

for (int i = 0; i < numbers.Count-1; i++)
{
    if (numbers[i] == numbers[i + 1])
    {
        sequence.Add(numbers[i]);
        
        if (sequence.Count > maxSequence)
        {
            maxSequence = sequence.Count;
            max.AddRange(sequence);            
        }
        
    }
    if (numbers[i] != numbers[i + 1])
        {
        sequence.Clear();
        }
    
}
 Console.WriteLine(string.Join(" ", max));
