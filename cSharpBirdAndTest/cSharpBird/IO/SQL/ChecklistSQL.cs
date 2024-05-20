namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Text.Json;

public class ChecklistSQL //: IAccessChecklistFile
{
    string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
    
    public List<Checklist> GetLists(User searchUser)
    {
        List<Checklist> userChecklists = new List<Checklist>();
        Guid badUID = new Guid("00000000-0000-0000-0000-000000000000");

        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        string cmdText = "SELECT checklistID, userId, locationName, checklistDateTime, birds, distance, duration, stationary, cNotes FROM checklists WHERE userId = @userId;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        cmd.Parameters.AddWithValue("@userId",searchUser.userId);

        using SqlDataReader reader = cmd.ExecuteReader();
     
        while(reader.Read())
        {
            if (reader.GetString(0) != null || reader.GetGuid(0) != badUID)
                userChecklists.Add(new Checklist(reader.GetGuid(0),reader.GetGuid(1),reader.GetString(2),reader.GetDateTime(3),JsonSerializer.Deserialize<List<Bird>>(reader.GetString(4)),reader.GetFloat(5),reader.GetInt32(6),reader.GetBoolean(7),reader.GetString(8)));
        }
        connection.Close();
        return userChecklists;
    }
    public void WriteChecklist(Checklist newList)
    {
        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "INSERT INTO checklists (checklistID, userId, locationName, checklistDateTime, birds, distance, duration, stationary, cNotes) VALUES (@checklistID, @userId, @locationName, @checklistDateTime, @birds, @distance, @duration, @stationary, @cNotes);";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@checklistID",newList.checklistID);
        cmd.Parameters.AddWithValue("@userId",newList.userId);
        cmd.Parameters.AddWithValue("@locationName",newList.locationName);
        cmd.Parameters.AddWithValue("@checklistDateTime",newList.checklistDateTime);
        cmd.Parameters.AddWithValue("@birds",JsonSerializer.Serialize(newList.birds));
        cmd.Parameters.AddWithValue("@distance",0);
        cmd.Parameters.AddWithValue("@duration",0);
        cmd.Parameters.AddWithValue("@stationary",0);
        cmd.Parameters.AddWithValue("@cNotes",newList.cNotes);
        /*
        if (user.displayName != null)
            cmd.Parameters.AddWithValue("@displayName",user.displayName);
        else
            cmd.Parameters.AddWithValue("@displayName","NULL");
        cmd.Parameters.AddWithValue("@hashedPW",user.hashedPW);
        */
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void WriteUpdatedList(Checklist updatedList)
    {
        using SqlConnection connection = new SqlConnection (_connectionstring);

        connection.Open();

        string cmdText = "UPDATE checklists SET checklistID=@checklistID, userId=@userId, locationName=@locationName, checklistDateTime=@checklistDateTime, birds=@birds, distance=@distance, duration=@duration, stationary=@stationary, cNotes=@cNotes WHERE checklistID = @checklistID;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@checklistID",updatedList.checklistID);
        cmd.Parameters.AddWithValue("@userId",updatedList.userId);
        cmd.Parameters.AddWithValue("@locationName",updatedList.locationName);
        cmd.Parameters.AddWithValue("@checklistDateTime",updatedList.checklistDateTime);
        cmd.Parameters.AddWithValue("@birds",JsonSerializer.Serialize(updatedList.birds));
        cmd.Parameters.AddWithValue("@distance",updatedList.distance);
        cmd.Parameters.AddWithValue("@duration",updatedList.duration);
        cmd.Parameters.AddWithValue("@stationary",updatedList.stationary);
        cmd.Parameters.AddWithValue("@cNotes",updatedList.cNotes);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
    public void DeleteChecklist(Checklist deleteChecklist)
    {
        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        string cmdText = "DELETE * FROM checklists WHERE checklistID = @checklistID;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        cmd.Parameters.AddWithValue("@checklistID",deleteChecklist.checklistID);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
}