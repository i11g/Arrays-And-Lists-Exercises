namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(' ');
            string[] second = Console.ReadLine().Split(' ');

            
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j <second.Length; j++)
                {
                    if (first[i] == second[j])
                    {
                        Console.Write(string.Join(",",first));
                    }   
                }

            }
        }
    }
}