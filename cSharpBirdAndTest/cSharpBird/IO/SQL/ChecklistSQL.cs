namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;

public class ChecklistSQL //: IAccessChecklistFile
{/*
    string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
    
    public List<Checklist> GetLists(User searchUser)
    {
        List<Checklist> userChecklists = new List<Checklist>();

        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        string cmdText = "SELECT checklistID, userId, locationName, checklistDateTime, birds, distance, duration, stationary, cNotes FROM checklists WHERE userId = @userId;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        cmd.Parameters.AddWithValue("@userId",searchUser.userId);

        using SqlDataReader reader = cmd.ExecuteReader();
     
        while(reader.Read())
        {
            if (reader.GetString(1) != null)
                userChecklists.Add(new Checklist(reader.GetGuid(0),reader.GetGuid(1),reader.GetString(2),reader.GetString(3)));
        }
        connection.Close();
        return userArchive;
    }
    public void WriteChecklist(Checklist newList)
    {

    }

    public void WriteUpdatedList(Checklist updatedList)
    {

    }
    public void DeleteChecklist(Checklist deleteChecklist)
    {

    }*/
}