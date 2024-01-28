namespace Reverse_Array_oF_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');

            ;
            for (int i = 0; i < line.Length/2; i++)
            {
                string temp = line[i];
                line[i] = line[line.Length-1-i];
                line[line.Length-1-i] = temp;
            }
            foreach (string temp in line)
            {
                Console.Write($"{temp} ");
            }
        }
    }
}