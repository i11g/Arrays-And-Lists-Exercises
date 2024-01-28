using System.Diagnostics.CodeAnalysis;

namespace Max_Sequence_Of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int longestSequence = 0;
            int sequesnce = 1;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                          
              if (numbers[i] == numbers[i+1])
                    {
                        sequesnce++;
                    }              

              if(sequesnce > longestSequence)
                    {
                        longestSequence = sequesnce;
                    }

              if (numbers[i] != numbers[i + 1])
                {
                    sequesnce = 1;
              
                }
            }
                Console.WriteLine(longestSequence);
            }
        }
    }
