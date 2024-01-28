namespace Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isGreater = true;
            for (int i = 0; i < num.Length; i++)
            {
                isGreater = true;
                for (int j =i+ 1; j < num.Length ; j++)
                {

                    if (num[i] < num[j])
                    {   
                        isGreater = false;
                        break;
                    }
                    
                }
                if(isGreater)
                {
                    Console.WriteLine(num[i]);
                }
               
                
            }
            
        }
    }
}