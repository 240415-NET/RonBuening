namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;
public class Admin
{
    public static void UserCheck(string[] adminSignOn)
    {
        if (adminSignOn[0] == "" && adminSignOn[1] == "key")
        {
            
        }
        else
        {
            Console.WriteLine("Sign-in failed");
        }
    }
}