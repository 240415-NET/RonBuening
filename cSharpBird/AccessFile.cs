namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class AccessFile.cs
{
    public static List<User> ReadUser()
    {
        string Path = "Users.json"
        List<User> userArchive = new List<user>;
        if (File.Exists(Path))
        {
            string existingUsersJSON =File.ReadAllText(Path);
            userArchive = JsonSerializer.Deserializer<List<User>>(existingUsersJSON);
        }
        else if(!File.(Exists(Path)))
        {
            userArchive.Add("defaultName");
            string existingUsersJSON = JsonSerializer.Serialize(userArchive);
            File.WriteAllText(Path,existingUsersJSON);
        }
        return userArchive;
    }
    public static void WriteUser (User user)
    {
        List<User> userArchive = new List<user>;
        if (File.Exists(Path))
        {
            string existingUsersJSON =File.ReadAllText(Path);
            userArchive = JsonSerializer.Deserializer<List<User>>(existingUsersJSON);

        }
        else
        {
            userArchive.Add("defaultName")
        }
    }
}