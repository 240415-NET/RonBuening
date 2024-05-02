namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UserMaintenance
{
    public static void LogIn()
    {
        Console.WriteLine("Moved to method!");
    }
    public static void LogIn(string email)
    {
        Console.WriteLine("Attempting sign-in!");
    }
    public static bool SignInSuccess (string email)
    {
        return true;
    }
}