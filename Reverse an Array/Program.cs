int num=int.Parse(Console.ReadLine());

int[] newArray = new int[num] ;  

for(int i=0; i<num; i++)
{
    int number=int.Parse(Console.ReadLine());
    newArray[i]=number;
}

for(int j=newArray.Length-1; j>=0; j--)
{
    Console.Write($"{newArray[j]} " );
}