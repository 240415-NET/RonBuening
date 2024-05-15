namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
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
    public static void StoreNusret(string salt, Guid UserId)
    {
        AccessUser.StoreNusret(salt,UserId);
    }
    public static string GetNusret(User user)
    {
        string currentSession = AccessUser.GetNusret(user);
        return currentSession;
    }
}