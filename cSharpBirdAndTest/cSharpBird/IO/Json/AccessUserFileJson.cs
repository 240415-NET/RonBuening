namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class AccessUserFileJson : IAccessUserFile
{
    public List<User> GetFullUserList()
    {
        //Will return the user list for the Users.json file, creating it and adding a defaultUser if file does not already exist
        //string pathFile = "Users.json";
        string path = "data\\users";
        string pathFile = path + "\\Users.json";
        List<User> userArchive = new List<User>();
        string existingUsersJSON;

        if (File.Exists(pathFile))
        {
            existingUsersJSON =File.ReadAllText(pathFile);
            userArchive = JsonSerializer.Deserialize<List<User>>(existingUsersJSON);
        }
        else if(!File.Exists(pathFile))
        {
            Directory.CreateDirectory(path);
            userArchive.Add(new User ("defaultName","password"));
            existingUsersJSON = JsonSerializer.Serialize(userArchive);
            File.WriteAllText(pathFile,existingUsersJSON);
        }
        return userArchive;
    }
    public void WriteUser(User user)
    {
        //This method will write a new user to the json file, creating it if it does not exist.
        //string pathFile = "Users.json";
        string path = "data\\users";
        string pathFile = path + "\\Users.json";
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
            Directory.CreateDirectory(path);
            userArchive.Add(new User ("defaultName","password"));
            existingUsersJSON = JsonSerializer.Serialize(userArchive);
            File.WriteAllText(pathFile,existingUsersJSON);
        }
    }
    public void WriteUpdatedUser(User updatedUser)
    {
        //This method will write a new user to the json file, creating it if it does not exist.
        //string pathFile = "Users.json";
        string path = "data\\users";
        string pathFile = path + "\\Users.json";
        List<User> userArchive = new List<User>();
        string existingUsersJSON;
        //int userLocation = -1;

        existingUsersJSON =File.ReadAllText(pathFile);
        userArchive = JsonSerializer.Deserialize<List<User>>(existingUsersJSON);
        //userArchive.FirstOrDefault(u => {if (u.userId == updatedUser.userId) {u = updatedUser;}}); //this was too smart apparently
        User oldUser = userArchive.First(i => i.userId == updatedUser.userId);
        var userLocation = userArchive.IndexOf(oldUser);
        if (userLocation != -1)
            userArchive[userLocation] = updatedUser;
        
        existingUsersJSON = JsonSerializer.Serialize(userArchive);
        File.WriteAllText(pathFile,existingUsersJSON);
    }
    public void WriteCurrentUser(User user)
    {
        //string pathFile = "CurrentUser.json";
        string path = "data\\users";
        string pathFile = path + "\\CurrentUser.json";
        if (!File.Exists(pathFile))
            Directory.CreateDirectory(path);
        File.WriteAllText(pathFile,JsonSerializer.Serialize(user));
    }
    public User ReadCurrentUser()
    {
        string path = "data\\users";
        string pathFile = path + "\\CurrentUser.json";
        if (!File.Exists(pathFile))
            Directory.CreateDirectory(path);
        User currentSession = JsonSerializer.Deserialize<User>(File.ReadAllText(pathFile));
        return currentSession;
    }
    public void ClearCurrentUser()
    {
        string path = "data\\users";
        string pathFile = path + "\\CurrentUser.json";
        if (!File.Exists(pathFile))
            Directory.CreateDirectory(path);
        File.WriteAllText(pathFile,"");
    }
    public void StoreNusret(string salt, Guid UserId)
    {
        string path = "data\\users\\"+UserId;
        string pathFile = path + "\\salt.json";
        if (!File.Exists(pathFile))
            Directory.CreateDirectory(path);
        File.WriteAllText(pathFile,salt);
    }
    public string GetNusret(User user)
    {
        string path = "data\\users\\"+user.userId;
        string pathFile = path + "\\salt.json";
        if (!File.Exists(pathFile))
            Directory.CreateDirectory(path);
        string currentSession = File.ReadAllText(pathFile);
        return currentSession;
    }
}