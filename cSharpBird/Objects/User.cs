namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class User
{
    public Guid userId {get; set;}
    public string userName {get; set;}
    public string displayName {get; set;}
    public User() {}

    public User(string _userName)
    {
        userId = Guid.NewGuid(); 
        userName = _userName;
    }

    public static void changeEmail(User user)
    {
        Console.WriteLine("What would you like to change your email to?");
        string newEmail = Console.ReadLine().Trim();
        if (String.IsNullOrEmpty(newEmail))
            Console.WriteLine("Email not updated");
        else
        {
            user.userName = newEmail;
            Console.WriteLine($"Email updated to {newEmail}");
        }
        
    }
    public static void changeName(User user)
    {
        Console.WriteLine("What would you like to change your display name to?");
        string newName = Console.ReadLine().Trim();
        if (String.IsNullOrEmpty(newName))
            Console.WriteLine("Name not updated");
        else
        {
            user.displayName = newName;
            Console.WriteLine($"Name updated to {newName}");
        }

    }
}