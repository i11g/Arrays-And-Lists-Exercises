using System.Diagnostics.CodeAnalysis;

int num=int.Parse(Console.ReadLine());
bool noSuchNumber = false;
for (int i = 1; i <=num ; i++)
{
    int currentNumber = i;
    
    int sum = 0;
    bool isAllDigitsPrime = false;
    isAllDigitsPrime = true;
    while (currentNumber>0)
    {   
        
        int lastDigit=currentNumber%10;
        currentNumber = currentNumber/10;
        bool isPrime = true;
        if (lastDigit == 1 || lastDigit == 0)
        {
            isPrime = false;
        }
        for (int j = 2; j < lastDigit ; j++)
        {
            if (lastDigit % j == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
        {
            sum += lastDigit;
            
        }
        else
        {
            isAllDigitsPrime = false;
        }
    }
    if(isAllDigitsPrime&&sum%2==0)
    {
        Console.WriteLine(i);
        noSuchNumber = true;
    }
    
}
if(!noSuchNumber)
{
    Console.WriteLine("no");
}

