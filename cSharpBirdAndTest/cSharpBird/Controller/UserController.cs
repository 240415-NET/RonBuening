namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
public class UserController
{
    public static IAccessUserFile AccessUser = new AccessUserFileJson();
    public static List<User> GetFullUserList()
    {
        List<User> userList = AccessUser.GetFullUserList();
        return userList;
    }
    public static void WriteUser(User user)
    {
        AccessUser.WriteUser(user);
    }
    public static void WriteUpdatedUser(User updatedUser)
    {
        AccessUser.WriteUpdatedUser(updatedUser);
    }
    public static void WriteCurrentUser(User user)
    {
        AccessUser.WriteCurrentUser(user);
    }
    public static User ReadCurrentUser()
    {
        User currentSession = AccessUser.ReadCurrentUser();
        return currentSession;
    }
    public static void ClearCurrentUser()
    {
        AccessUser.ClearCurrentUser();
    }
    public static User FindUser(string user)
    {
        User foundUser = User.FindUser(user);
        return foundUser;
    }
    public static void changeEmail(User user)
    {
        User.changeEmail(user);        
    }
    public static void changeName(User user)
    {
        User.changeName(user);
    }
    public static bool ValidUserSession()
    {
        bool valid = AccessUser.ValidUserSession();
        return valid;
    }
    public static void StoreSalt(string salt, Guid UserId)
    {
        
        AccessUser.StoreSalt(salt,UserId);
    }
    public static string GetSalt(User user)
    {
        string currentSession = AccessUser.GetSalt(user);
        return currentSession;
    }
    public static void UpdatePassword(string password1,User user)
    {
        string hashedPW = "";
        hashedPW = CryptoController.InitHashPassword(user.userId,password1);
        user.hashedPW = hashedPW;
        WriteUpdatedUser(user);
    }
    public static bool ValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        if (email.EndsWith("."))
            return false;
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}