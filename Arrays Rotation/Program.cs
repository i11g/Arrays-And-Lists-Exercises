namespace Arrays_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberOfRotations=int.Parse(Console.ReadLine());
            
            int temp = 0;
            int sum = 1;
            int[] rotated= new int[num.Length];

            while (sum<=numberOfRotations)
            {
                for (int i = 0; i < num.Length-1; i++)
                {
                    temp = num[i + 1];
                    num[i + 1] = num[i];
                    num[i] = temp;
                }
                sum++;               
            }
            Console.WriteLine(string.Join(" ",num));
        }
    }
}