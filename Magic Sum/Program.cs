namespace Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            int magicNumber=int.Parse(Console.ReadLine());

            int magicSum = 0;
            for (int i = 0; i <numbers.Length; i++)
            {   

                for (int j = i+1; j <numbers.Length; j++)
                {
                    magicSum = numbers[i] + numbers[j];
                    if(magicSum==magicNumber)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
            }  
        }
    }
}