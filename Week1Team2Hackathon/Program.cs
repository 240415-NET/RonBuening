namespace Week1Team2Hackathon;

class Program
{
    static void Main(string[] args)
    {
        /*
        1 - Prompts the user for some input
        2 - Does something with that input
        3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
        4 - Continues to run until the user quits the application, from within the application (no ctrl+c)
        */

        double checkoutTotal = 0;
        double itemValue = 0;
        double amountTendered = 0;
        int numberItems = 0;
        string userInput;
        bool quit = false;

        do
        {
            try
            {
                Console.WriteLine("Please enter value of the item or enter 'q' to end transaction");
                userInput = Console.ReadLine();
                if (userInput == "q" || userInput == "Q")
                {
                    Console.WriteLine($"${checkoutTotal} is owed today for {numberItems} items");
                    Console.WriteLine("Please enter amount tendered");
                    amountTendered = Convert.ToDouble(Console.ReadLine());
                    if (amountTendered-checkoutTotal >= 0)
                    {
                        Console.WriteLine($"${amountTendered-checkoutTotal} is owed in change");
                    }
                    else
                    {
                        Console.WriteLine($"An additional {-(amountTendered-checkoutTotal)} is needed.");
                    }
                    quit = true;
                }
                else
                {
                    itemValue = Convert.ToDouble(userInput);
                    checkoutTotal = RunningTotal(itemValue,checkoutTotal);
                    numberItems = ItterateNumItems(numberItems);
                    if (numberItems > 1)
                    {
                        Console.WriteLine($"Subtotal is ${checkoutTotal}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter either a valid number or q to end transaction");
            }
        }
        while (quit == false);

    }

    static int ItterateNumItems(int numberItems)
    {
        int num1 = numberItems + 1;
        return num1;
    } 
   
    static double RunningTotal (double itemValue, double total)
    {
        total = total + itemValue;
        return total;
    }
}
