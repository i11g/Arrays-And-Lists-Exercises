namespace Equal_Sums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;
            int currentNumber = 0;

            for (int i = 0; i <numbers.Length; i++)
            {
                
                leftSum = 0;
                rightSum = 0;
                for (int j = i+1; j <numbers.Length; j++)
                {
                       rightSum += numbers[j];
                }
                for (int k = i-1; k>=0; k--)
                {
                    leftSum += numbers[k];
                }
                if (leftSum==rightSum)
                {
                    currentNumber = i;
                    break;
                }
                
            }
            if(leftSum==rightSum)
            {
                Console.WriteLine(currentNumber);
            }
            else if (leftSum != rightSum)
            {
                Console.WriteLine("no");
            }

        }
    }
}