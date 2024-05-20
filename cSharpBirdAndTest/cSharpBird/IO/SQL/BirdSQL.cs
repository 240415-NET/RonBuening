namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Data.SqlClient;
public class BirdSQL : IAccessBird
{
    string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
    public List<Bird> GetFullBirdList()
    {
        //pulls full bird species data from a given csv. two files are currently present; USGSBBL.csv for the USGS Bird Banding Laboratory codes and ABACL for American Birding Association codes.
        //update line 15 to change standards
        string bandCode = "";
        string speciesName = "";
        string path = "data\\BirdCSV\\";
        string pathFile = path + "USGSBBL.csv";
        List<Bird> birdList = new List<Bird>();
        birdList = File.ReadAllLines(pathFile)
            .Select(line => line.Split(','))
            .Select(x => new Bird{
                bandCode = x[0],
                speciesName = x[1]
            }).ToList();

        return birdList;
    }
    public void WriteBirdsForChecklist(Checklist checklist)
    {
        using SqlConnection connection = new SqlConnection (_connectionstring);
        List<Bird> bird = checklist.birds;
        connection.Open();

        for (int i =0; i < bird.Length; i++)
        {
            string cmdText = "INSERT INTO birds (checklistID, bandCode, speciesName, numSeen, bbc, bnotes) VALUES (@checklistID, @bandCode, @speciesName, @numSeen, @bbc, @bnotes);";

            using SqlCommand cmd = new SqlCommand(cmdText,connection);

            cmd.Parameters.AddWithValue("@checklistID",checklist.checklistID);
            cmd.Parameters.AddWithValue("@bandCode",bird.bandCode[i]);
            cmd.Parameters.AddWithValue("@bandCode",bird.speciesName[i]);
            cmd.Parameters.AddWithValue("@bandCode",bird.numSeen[i]);
            cmd.Parameters.AddWithValue("@bandCode",bird.bbc[i]);
            cmd.Parameters.AddWithValue("@bandCode",bird.bandCode[i]);

            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }
    public void UpdateBirdsForChecklist(Checklist checklist)
    {
        using SqlConnection connection = new SqlConnection (_connectionstring);
        List<Bird> bird = checklist.birds;
        connection.Open();

        for (int i =0; i < bird.Length; i++)
        {
            string cmdText = "UPDATE birds SET checklistID = @checklistID, bandCode = @bandCode, speciesName = @speciesName, numSeen = @numSeen, bbc = @bbc, bnotes = @bNotes WHERE checklistID = @checklistID AND bandCode = @bandCode;";

            using SqlCommand cmd = new SqlCommand(cmdText,connection);

            cmd.Parameters.AddWithValue("@checklistID",checklist.checklistID);
            cmd.Parameters.AddWithValue("@bandCode",bird.bandCode[i]);
            cmd.Parameters.AddWithValue("@speciesName",bird.speciesName[i]);
            cmd.Parameters.AddWithValue("@numSeen",bird.numSeen[i]);
            cmd.Parameters.AddWithValue("@bbc",bird.bbc[i]);
            cmd.Parameters.AddWithValue("@bNotes",bird.bNotes[i]);

            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }
    public List<Bird> ReadBirdsForChecklist(Guid checklistID)
    {
        List<Bird> checklistBirds = new List<Bird>();
        Guid badUID = new Guid("00000000-0000-0000-0000-000000000000");
        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();
        string bandCode = "";
        string speciesName = "";
        int numSeen = 0;
        string bbc = "";
        string bNotes = "";
        string cmdText = "SELECT checklistID, bandCode, speciesName, numSeen, bbc, bnotes FROM birds WHERE checklistID = @checklistID;";

        using SqlCommand cmd = new SqlCommand(cmdText,connection);
        cmd.Parameters.AddWithValue("@checklistID",checklistID);
        using SqlDataReader reader = cmd.ExecuteReader();
        int i = 0;
        try
        {
            while(reader.Read())
            {
                bandCode = reader.GetString(0);
                speciesName = reader.GetString(1);
                numSeen = reader.GetInt32(2);
                bbc = reader.GetString(3);
                bNotes = reader.GetString(4);
                checklistBirds.Add(new Bird(bandCode,speciesName,numSeen,bbc,bNotes));
            }
        }
        catch(Exception e){
            Console.WriteLine(e.StackTrace);
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
        
       
        connection.Close();
        return checklistBirds;
    }
}