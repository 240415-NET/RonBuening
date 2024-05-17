namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
//using System.Threading.Tasks;

public class UserSQL : IAccessUserFile
{
    string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
    public List<User> GetFullUserList()
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        //Credit to the Team2 for troubleshooting the SQL Data connection

        List<User> userArchive = new List<User>();

        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        string cmdText = "SELECT userId, userName, displayName, hashedPW FROM users;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        using SqlDataReader reader = cmd.ExecuteReader();
     
        while(reader.Read())
        {
            if (reader.GetString(2) != "NULL")
                userArchive.Add(new User(reader.GetGuid(0),reader.GetString(1),reader.GetString(2),reader.GetString(3)));
            else
                userArchive.Add(new User(reader.GetGuid(0),reader.GetString(1),null,reader.GetString(3)));
        }
        connection.Close();
        return userArchive;
    }

    public void WriteUser(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "INSERT INTO users (userId,userName,displayName,hashedPW) VALUES (@userId,@userName,@displayName,@hashedPW);";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        if (user.displayName != null)
            cmd.Parameters.AddWithValue("@displayName",user.displayName);
        else
            cmd.Parameters.AddWithValue("@displayName","NULL");
        cmd.Parameters.AddWithValue("@hashedPW",user.hashedPW);

        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void WriteUpdatedUser(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "UPDATE users SET userName = @userName, displayName = @displayName, hashedPW = @hashedPW WHERE userId = @userId;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        if (user.displayName != null)
            cmd.Parameters.AddWithValue("@displayName",user.displayName);
        else
            cmd.Parameters.AddWithValue("@displayName","NULL");
        cmd.Parameters.AddWithValue("@hashedPW",user.hashedPW);

        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void WriteCurrentUser(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        ClearCurrentUser();

        string cmdText = "INSERT INTO currentUser (userId,userName,displayName,hashedPW) VALUES (@userId,@userName,@displayName,@hashedPW);";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        if (user.displayName != null)
            cmd.Parameters.AddWithValue("@displayName",user.displayName);
        else
            cmd.Parameters.AddWithValue("@displayName","NULL");
        cmd.Parameters.AddWithValue("@hashedPW",user.hashedPW);

        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public User ReadCurrentUser()
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        List<User> userArchive = new List<User>();

        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        string cmdText = "SELECT userId, userName, displayName, hashedPW FROM checklists;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            if (reader.GetString(2) != "NULL")
                userArchive.Add(new User(reader.GetGuid(0),reader.GetString(1),reader.GetString(2),reader.GetString(3)));
            else
                userArchive.Add(new User(reader.GetGuid(0),reader.GetString(1),null,reader.GetString(3)));
        }

        connection.Close();

        return userArchive[1];
    }

    public void ClearCurrentUser()
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "DELETE FROM currentUser;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
    
    public bool ValidUserSession()
    {
        try
        {
            User user = ReadCurrentUser();
            if (user.userId == null)
                return false;
            else
                return true;
        }
        catch (Exception e){
            return false;
        }
    }

    public void StoreSalt(string salt, Guid UserId)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();
        
        string cmdText = "INSERT INTO salt (userId,salt) VALUES (@userId,@salt);";
        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",UserId);
        cmd.Parameters.AddWithValue("@salt",salt);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
    
    public string GetSalt(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
        using SqlConnection connection = new SqlConnection (_connectionstring);
        string salt = "";

        connection.Open();
        
        string cmdText = "Select salt FROM salt WHERE userId = @userId;";
        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@salt",salt);

        using SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
           salt = reader.GetString(0);
        }

        connection.Close();

        return salt;
    }
    public void UpdateSalt(string salt, Guid UserId)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "UPDATE salt SET salt = @salt WHERE userId = @userId;";
        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",UserId);
        cmd.Parameters.AddWithValue("@salt",salt);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
}