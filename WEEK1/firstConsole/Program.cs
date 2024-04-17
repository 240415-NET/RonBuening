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

        string name; //Values can be declared at a later time
        name = "Ron"; //And the value is then declared using the assignment operator
        //Strings can be either null or empty -- it is empty if you assign it to be "", null if value is undeclared or specifically declared null. This can matter if you're looking for specific states

        bool condition =true;
        condition = false;
        
    }

}
