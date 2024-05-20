namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Data.SqlClient;
public class BirdSQL : IAccessBird
{
    string _connectionstring = File.ReadAllText("C:\\Users\\U0LA19\\Documents\\cSharpBird_DataSource.txt");
    public List<Bird> GetFullBirdList();
    public void WriteBirdsForChecklist(Checklist checklist);
    public List<Bird> ReadBirdsForChecklist(Checklist checklist);
}