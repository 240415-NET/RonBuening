namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class AccessFile
{
    public static List<User> ReadUser()
    {
        //Will return the user list for the Users.json file, creating it and adding a defaultUser if file does not already exist
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
        //This method will write a new user to the json file, creating it if it does not exist.
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
    public static void WriteUpdatedUser(User updatedUser)
    {
        //This method will write a new user to the json file, creating it if it does not exist.
        string pathFile = "Users.json";
        List<User> userArchive = new List<User>();
        string existingUsersJSON;

        existingUsersJSON =File.ReadAllText(pathFile);
        userArchive = JsonSerializer.Deserialize<List<User>>(existingUsersJSON);
        updatedUser = userArchive.FirstOrDefault(u => u.userId == updatedUser.userId);

        existingUsersJSON = JsonSerializer.Serialize(userArchive);
        File.WriteAllText(pathFile,existingUsersJSON);
    }
    public static void WriteCurrentUser(User user)
    {
        string pathFile = "CurrentUser.json";
        //string existingUsersJSON;

        //existingUsersJSON = JsonSerializer.Serialize(user);
        File.WriteAllText(pathFile,JsonSerializer.Serialize(user));
    }
    public static User ReadCurrentUser()
    {
        string pathFile = "CurrentUser.json";
        User currentSession = JsonSerializer.Deserialize<User>(File.ReadAllText(pathFile));
        return currentSession;
    }
    public static void ClearCurrentUser()
    {
        string pathFile = "CurrentUser.json";
        File.WriteAllText(pathFile,"");
    }

}