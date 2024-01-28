using System.Runtime.InteropServices;

namespace Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
             int[] items=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;
            int differenceIndex = 0;
            bool isEqual = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j <=i ; j++)
                {
                    if (numbers[i] == items[j])
                    {
                        sum += numbers[i];
                    }
                    else
                    {
                        isEqual=false;
                        differenceIndex = i;
                        break;
                    }
                }
                if (!isEqual)
                {
                    break;
                }
            }
            if (!isEqual)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {differenceIndex}");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}