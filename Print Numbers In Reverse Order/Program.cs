namespace Print_Numbers_In_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int num=int.Parse(Console.ReadLine());

            int[] numbers= new int[num];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]= int.Parse(Console.ReadLine());  

            }
            for (int i = numbers.Length-1; i >=0; i--)
            {
                Console.Write(numbers[i]+" ");
            }
        }
    }
}