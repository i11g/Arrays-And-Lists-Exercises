namespace Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(' ');
            string[] second = Console.ReadLine().Split(' ');
            string common = "";

            for (int i = 0; i < first.Length ; i++)
            {
                if (first[i] == second[i])
                {
                    common =common + first[i];
                }
            }
            Console.WriteLine(common+ "  ");
        }
    }
}