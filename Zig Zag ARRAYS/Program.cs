
int number=int.Parse(Console.ReadLine());
int[] numbers1 = new int[number];
int[] numbers2 = new int[number];
bool addToFirstArray = true;

for (int i = 0; i <number; i++)
{
    
    string [] input=Console.ReadLine().Split(' ');
    int num1 = int.Parse(input[0]);
    int num2 = int.Parse(input[1]);
   

        if (addToFirstArray)
        {
            numbers1[i] = num1;
            numbers2[i] = num2;
            addToFirstArray = false;
        }
        else
        {
            numbers1[i] = num2;
            numbers2[i] = num1;
            addToFirstArray = true;
        }
       //addToFirstArray=!addToFisrtArray;          
}      


Console.WriteLine(string.Join(" ", numbers1));
Console.WriteLine(string.Join(" ", numbers2));
