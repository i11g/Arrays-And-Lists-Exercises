namespace Reading_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] numbers = new int[num];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}