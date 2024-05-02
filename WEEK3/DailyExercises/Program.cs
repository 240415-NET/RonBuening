namespace DailyExercises;

using System;



public class Test
{

    public static int rockGame(int b, int s, int t)
    {
        //WRITE YOUR CODE HERE
        /*
            Players need to turns
            Turns need to run until the number of rocks in bag <= 0
        */
        int turn = 1;
        int sumS = 0;
        int sumT = 0;
        int winCount = 0;
        do
        {
            if (turn % 2 != 0 && b > s)
            {
                b = b - s;
                sumS += s;
            }
            else if (turn % 2 != 0 && b <= s)
            {
                sumS += b;
                b = 0;
                winCount = sumS;
            }
            else if (turn % 2 == 0 && b > t)
            {
                b = b - t;
                sumT += t;
            }
            else if (turn % 2 == 0 && b <= t)
            {
                sumT += b;
                b = 0;
                winCount = sumT;
            }
            turn++;
        }
        while (b > 0);

        return winCount;
    }

    //DO NOT TOUCH THE CODE BELOW
    public static void Main()
    {
        int b = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        int t = int.Parse(Console.ReadLine());
        Console.WriteLine(rockGame(b, s, t));
    }

}