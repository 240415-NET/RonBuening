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
    public static User (string user)
    {
        User foundUser = User.FindUser(user);
        return foundUser;
    }
}