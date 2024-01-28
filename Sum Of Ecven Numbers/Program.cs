namespace Sum_Of_Ecven_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sumEven = 0;
            for (int i = 0; i <numbers.Length; i++)
            {
                if (numbers[i]%2 == 0)
                {
                    sumEven += numbers[i];
                }
                
            }
            Console.WriteLine(sumEven);
        }
    }
}