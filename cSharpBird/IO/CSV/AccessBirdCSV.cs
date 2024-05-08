namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class AccessBirdCSV : IAccessBird
{
    public List<Bird> GetFullBirdList()
    {
        long speciesNum = 0;
        string bandCode = "";
        string speciesName = "";

        //Will return the user list for the Users.json file, creating it and adding a defaultUser if file does not already exist
        string pathFile = "USGSBBL.csv";
        List<Bird> birdList = new List<Bird>();
        birdList = File.ReadAllLines(pathFile)
            .Select(line => line.Split(','))
            .Select(x => new Bird{
                speciesNum = long.Parse(x[0]),
                bandCode = x[1],
                speciesName = x[2]
            }).ToList();
        return birdList;
    }
}