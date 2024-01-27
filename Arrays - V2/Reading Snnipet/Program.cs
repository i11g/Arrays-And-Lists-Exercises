namespace Reading_Snnipet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value=Console.ReadLine();

            int[] numbers = value.Split( ' ').Select(int.Parse).ToArray();

            int[] numbers1=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
    }
}