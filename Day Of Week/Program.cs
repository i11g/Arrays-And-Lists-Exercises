int num = int.Parse(Console.ReadLine());

string[] daysOfWeek = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }; 

if(num==1)
{
    Console.WriteLine(daysOfWeek[0]);
}
else if(num==2) 
{
    Console.WriteLine(daysOfWeek[1]);
}
else if (num == 3)
{
    Console.WriteLine(daysOfWeek[2]);
}
else if (num == 4)
{
    Console.WriteLine(daysOfWeek[3]);
}
else if (num == 5)
{
    Console.WriteLine(daysOfWeek[4]);
}
else if (num == 6)
{
    Console.WriteLine(daysOfWeek[5]);
}
else if (num == 7)
{
    Console.WriteLine(daysOfWeek[6]);
}
else
{
    Console.WriteLine("Invalid day!");
}