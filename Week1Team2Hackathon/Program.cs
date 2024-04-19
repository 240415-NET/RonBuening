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
                    quit = true;
                }
                else
                {
                    itemValue = Convert.ToDouble(userInput);
                    checkoutTotal = checkoutTotal + itemValue;
                    numberItems++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter either a valid number or q to end transaction");
            }
        }
        while (quit == false);

    }
}
