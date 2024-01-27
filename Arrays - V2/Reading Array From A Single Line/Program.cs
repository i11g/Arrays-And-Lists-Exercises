namespace Reading_Array_From_A_Single_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value=Console.ReadLine();

            string[] items = value.Split(' ');

            int[] numbers = new int[items.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(items[i]);
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}