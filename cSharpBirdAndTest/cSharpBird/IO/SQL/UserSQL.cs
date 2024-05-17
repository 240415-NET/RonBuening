namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
//using System.Threading.Tasks;

public class UserSQL //: IAccessUserFile
{
    string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
    public static List<User> GetFullUserList()
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        //Credit to the Team2 for troubleshooting the SQL Data connection

        List<User> userArchive = new List<User>();

        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        string cmdText = "SELECT checklistID, userId, locationName, checklistDateTime, birds, distance, duration, stationary, cNotes FROM checklists;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            userArchive.Add(new User(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetString(3)));
        }
        connection.Close();

        return userArchive;
    }

    public static void WriteUser(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "INSERT INTO users (userId,userName,displayName,hashedPW) VALUES (@userId,@userName,@displayName,@hashedPW);";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        cmd.Parameters.AddWithValue("@displayName",user.displayName);
        cmd.Parameters.AddWithValue("@hashedPW",user.hashedPW);

        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void WriteUpdatedUser(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "UPDATE users SET (userName = @userName, displayName = @displayName, hashedPW = @hashedPW) WHERE userId = @userId;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        cmd.Parameters.AddWithValue("@displayName",user.displayName);
        cmd.Parameters.AddWithValue("@hashedPW",user.hashedPW);

        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void WriteCurrentUser(User user)
    {
        string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");

        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "INSERT INTO currentUser (userId,userName,displayName,hashedPW) VALUES (@userId,@userName,@displayName,@hashedPW);";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        cmd.Parameters.AddWithValue("@displayName",user.displayName);
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
            userArchive.Add(new User(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetString(3)));
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
        return false;
    }

    public void StoreSalt(string salt, Guid UserId)
    {

    }
    
    public string GetSalt(User user)
    {
        string nonsenseNull = "";
        return nonsenseNull;
    }
    public void UpdateSalt(string salt, Guid UserId)
    {

    }
}