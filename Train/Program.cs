namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberVagons=int.Parse(Console.ReadLine());
            int[] number = new int[numberVagons];
            int sum = 0;
            for (int i = 0; i < numberVagons ; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());
                sum+= numberOfPeople;
                number[i] = numberOfPeople;

            }
            Console.WriteLine(string.Join(" ", number));
            Console.WriteLine(sum);
        }
    }
}