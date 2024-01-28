namespace Even_Or_Odd_Substraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sumEven = 0;
            int sumOdd = 0;
            int difference = 0;
            for (int i = 0; i <numbers.Length; i++)
            {
                if (numbers[i]%2==0)
                {
                    sumEven += numbers[i];
                }
                else
                {
                    sumOdd += numbers[i];
                }
                difference = sumEven - sumOdd;
            }
            Console.WriteLine(difference);
        }
    }
}