namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class Bird
{
    public Guid speciesID {get; set;}
    public string speciesName {get; set;}
    public string rarity {get; set;}
    public Bird() {}

    public Bird(string _speciesName)
    {
        speciesId = Guid.NewGuid(); 
        speciesName = _speciesName;
        rarity = "Common";
    }
    public Bird(string _speciesName, string _rarity)
    {
        speciesId = Guid.NewGuid(); 
        speciesName = _speciesName;
        rarity = _rarity;
    }
}