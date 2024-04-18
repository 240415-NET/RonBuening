//Include libraries with pre-written code from outside of our application with the USING statement
using System; 

//A namespace is a 'filing cabinet' of sorts, where many different blocks of code or files can be stored and remain accessible to one another
namespace firstConsole;

//Classes contain members which are called fields and methods
//Fields are variables that store data, e.g. integers, strings, etc.
//Methods are functions contain processes that can manipulate that data or perform actions and can be re-used throughout the code
class Program
{
    //The method 'Main' is the entry point to the program, and the first thing that is executed in the program.
    //The "string[] args" piece is used to pass in the arguments from the console when main is called.
    //This is largely a legacy item, originating from when most interactions came from the console/command line
    static void Main(string[] args)
    {
        //C# does not care about indentations, just lines and logical blocks of code
        //A logical block of code is that which is contained within the curly braces '{}'; see how both the class and method are enclosed in their own nesting set of braces?
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Something else");

         /* 
        Common variable types include:
        1. int, an integer value
        2. double, float, a decimal value
        3. char, a single character
        4. string, a series of characters treated as an array of characters
        5. boolean, containing either true or false
        */
        
        //This is a declaration of an integer variable; (type), (name), and (value) are defined
        //Here the '=' is an assignment operator; not to be confused with the '==' operand for a comparator

        int age = 5;
        Console.WriteLine(age);

        //numeric type conversion, explicit and implicit
        double someDecimal = 4.4;
        int someInteger = (int)someDecimal;
        //this explicit conversion will lose everything to the right of the decimal and C# will force you to include this conversion
        int someOtherInteger = 5;
        double someOtherDecimal = someOtherInteger;
        //this implicit conversion does not need a function as there is no data loss
        //generally, if you will lose precision or data, you must be explicit
        //however, not all types can be explicity converted between and you will need to use the convert method


        string name; //Values can be declared at a later time
        name = "Ron"; //And the value is then declared using the assignment operator
        //Strings can be either null or empty -- it is empty if you assign it to be "", null if value is undeclared or specifically declared null. This can matter if you're looking for specific states

        bool condition =true;
        condition = false;
        
        // This is code with an error
        //char conDen;
        /*
        Console.WriteLine(name," age is ",age,"correct?");
        Console.WriteLine("Y for yes, N for no")
        char conDen = Console.ReadLine();
        if (conDen == 'Y')
        {
            Console.WriteLine("Great!");
        }
        else if (conDen == 'N')
        {
            Console.WriteLine("Please enter correct age");
        }
        else
        {
            Console.WriteLine("Please enter valid character");
        }
        */

        /* 
        Logical operators:
        1. ||, used for logical OR operator; if either is true, evaluates true
        2. &&, used for logical AND operator; if both are true, evaluates true
        3. !, used for logical NOT operator; inverts condition and is placed immediately before condition/variable
        */

        /*
        Comparison operators, returning true or false bools
        1. ==, equal to, returns true if both are equal
        2. !=, not equal, returns true if values are not equal
        3. >, greater than
        4. <, less than
        5. >=, greater than or equal
        6. <=, less than or equal
        */

        //control flow basics and conditional statements
        int newInt = 4;
        Console.WriteLine("Please provide a number");
        //Need to understand why this doesn't work?        
        //newInt = Convert.ChangeType(Console.ReadLine(),typeof(int));

        //This takes newInt and assigns it a value from a string that is converted to an int to fit newInt
       
        newInt = Convert.ToInt32(Console.ReadLine());
        //Alternate interpretation:
        //string userInput = Console.ReadLine();
        //int userNumber = Convert.ToInt32(userInput);

        if (newInt == 4)
        {
            Console.WriteLine(name,", newInt equals 4!");
        }
        else if(newInt >= 8)
        {
            Console.WriteLine(name,", newInt is greater than 7!");
        }
        else
        {
            Console.WriteLine(name,", newint is either less than 4 or between 5 and 7");
        }
    }

}
