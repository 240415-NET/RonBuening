namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class AccessFile
{
    public static List<User> ReadUser()
    {
        string pathFile = "Users.json";
        List<User> userArchive = new List<User>();
        string existingUsersJSON;

        if (File.Exists(pathFile))
        {
            existingUsersJSON =File.ReadAllText(pathFile);
            userArchive = JsonSerializer.Deserialize<List<User>>(existingUsersJSON);
        }
        else if(!File.Exists(pathFile))
        {
            userArchive.Add(new User ("defaultName"));
            existingUsersJSON = JsonSerializer.Serialize(userArchive);
            File.WriteAllText(pathFile,existingUsersJSON);
        }
        return userArchive;
    }
    public static void WriteUser(User user)
    {
        string pathFile = "Users.json";
        List<User> userArchive = new List<User>();
        string existingUsersJSON;
        if (File.Exists(pathFile))
        {
            existingUsersJSON =File.ReadAllText(pathFile);
            userArchive = JsonSerializer.Deserialize<List<User>>(existingUsersJSON);
            userArchive.Add(user);
            existingUsersJSON = JsonSerializer.Serialize(userArchive);
            File.WriteAllText(pathFile,existingUsersJSON);
        }
        else if(!File.Exists(pathFile))
        {
            userArchive.Add(new User ("defaultName"));
            existingUsersJSON = JsonSerializer.Serialize(userArchive);
            File.WriteAllText(pathFile,existingUsersJSON);
        }
    }
}