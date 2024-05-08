namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class IAccessUserFile
{
     public static List<User> GetFullUserList()

    public static void WriteUser(User user)

    public static void WriteUpdatedUser(User updatedUser)

    public static void WriteCurrentUser(User user)

    public static User ReadCurrentUser()

    public static void ClearCurrentUser()


}