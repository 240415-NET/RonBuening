namespace ExceptionHandlingUXImprove;

class Program
{
    static void Main(string[] args)
    {
        int val1 = 0; //values need to be assigned to val1 and val2 to ensure that a value is present for line 36 outside the do-while/try-catch blocks
        int val2 = 0; //this is caught by the compiler and it does not recognize the values _will_ get assigned in the do-while loop
        bool test1 = false;
        bool test2 = false;
        
        //having a single do-while loop will require the user to key both values again if val2 is invalid
        while (test1 == false)
        {
            try //code we are QCing to ensure there's not a crash
            {
                Console.WriteLine("Please key value 1");
                val1 = Convert.ToInt32(Console.ReadLine());
                //Below uses string interpolation to insert the values and answer. Note the '$' at the beginning of the string. 
                //Placement here does not require the assignment of values at the start of the code
                //Console.WriteLine($"The sum of {val1} and {val2} is {AddTwoNumbers(val1,val2)}");
                test1 = true;
            }
            catch (Exception e) //doing something when there's a potential exception; there may be multiple catch statements based on the needs of the program and type of exception
            {
                Console.Clear();
                //This sort of statement will print the exception's message to the user
                Console.WriteLine($"{e.Message} Please enter an integer value.");
                //Console.WriteLine($"{e.StackTrace} is the error location");
            }
           //finally //will always execute after the first two commands
            //{

            //}
        }
        
        while (test2 == false)
        {
            try //code we are QCing to ensure there's not a crash
            {
                Console.WriteLine("Please key value 2");
                val2 = Convert.ToInt32(Console.ReadLine());
                //Below uses string interpolation to insert the values and answer. Note the '$' at the beginning of the string. 
                //Placement here does not require the assignment of values at the start of the code
                //Console.WriteLine($"The sum of {val1} and {val2} is {AddTwoNumbers(val1,val2)}");
                test2 = true;
            }
            catch (Exception e) //doing something when there's a potential exception; there may be multiple catch statements based on the needs of the program and type of exception
            {
                Console.Clear();
                //This sort of statement will print the exception's message to the user
                Console.WriteLine($"{e.Message} Please enter an integer value.");
                //Console.WriteLine($"{e.StackTrace} is the error location");
            }
           //finally //will always execute after the first two commands
            //{

            //}
        }

        //Below uses string interpolation to insert the values and answer. Note the '$' at the beginning of the string. 
        //Placement here requires the assignment of values at the start of the code
        Console.WriteLine($"The sum of {val1} and {val2} is {AddTwoNumbers(val1,val2)}");
       
    }
    static int AddTwoNumbers(int num1, int num2)
    {
        return num1 + num2;
    }

}
