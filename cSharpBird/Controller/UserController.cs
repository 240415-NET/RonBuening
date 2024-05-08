namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UserController
{
    public static List<User> GetFullUserList()
    {
        List<User> userList = AccessFile.ReadUser();
        return userList();
    }
    public static void WriteUser(User user)
    {
        AccessFile.WriteUser(user);
    }
    public static void WriteUpdatedUser(User updatedUser)
    {
        AccessFile.WriteUpdatedUser(user);
    }
    public static void WriteCurrentUser(User user)
    {
        AccessFile.WriteCurrentUser(user);
    }
    public static User ReadCurrentUser()
    {
        User currentSession = AccessFile.ReadCurrentUser();
        return currentSession;
    }
    public static void ClearCurrentUser()
    {
        AccessFile.ClearCurrentUser();
    }