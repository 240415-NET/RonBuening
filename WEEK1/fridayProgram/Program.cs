namespace fridayProgram;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please key value 1 as int");
        int val1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please key value 2 as int");
        int val2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The sum of the two values is " + AddTwoNumbers(val1,val2));
    }

    //static methods vs dynamic methods will be discussed next week; these are access modifiers
    //the second item is the return type; void means it does not necessarily need to return a value
    //third item is names, done in Pascal case to indicate that it is a method and not a variable
    static int AddTwoNumbers(int num1, int num2)
    {
        return num1 + num2;
    }
}