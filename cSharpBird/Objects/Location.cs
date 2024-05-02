namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class Location
{
    public Guid locationID {get; set;}
    public string locationName {get; set;}
    public string county {get; set;}
    public string state {get; set;}
    public Location() {}

    public Location(string _locationName)
    {
        speciesId = Guid.NewGuid(); 
        speciesName = _speciesName;
        county = "Pinellas";
        state = "Florida";
    }
     public Location(string _locationName, string _state, string _county)
    {
        speciesId = Guid.NewGuid(); 
        speciesName = _speciesName;
        county = _county;
        state = _state;
    }
}