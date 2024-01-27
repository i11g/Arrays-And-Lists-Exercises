namespace Reverse_Array_Of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(' ');

            string currentitem="";
            for (int i = 0; i < items.Length/2; i++)
            {   
                currentitem = items[i];
                items[i] = items[items.Length-1-i];
                items[items.Length-1-i]=currentitem;
            }

            Console.WriteLine(string.Join(",",items));
        }
    }
}