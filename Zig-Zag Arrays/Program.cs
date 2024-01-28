using System.Globalization;

namespace Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num=int.Parse(Console.ReadLine());

            int currentNumber = 0;
            int nextNumber=0;
            int[] first = new int[num];
            int[] second = new int[num];
            for (int i = 0; i <num; i++)
            {   
                
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                currentNumber = numbers[0]; nextNumber = numbers[1];
                for (int j = i; j <=i; j++)
                {
                    if (j % 2 == 0)
                    {
                        first[j] = currentNumber;
                        second[j] = nextNumber;
                    }
                    else
                    {
                        first[j] = nextNumber;
                        second[j] = currentNumber;
                    }
                    
                }
                
            }
            
            Console.WriteLine(string.Join(" ",first));
            Console.WriteLine(string.Join(" ",second));






        }         
    }
}