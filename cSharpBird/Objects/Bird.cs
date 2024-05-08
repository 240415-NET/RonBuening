namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class Bird
{
    //public Guid speciesID {get; set;}
    public string bandCode {get; set;}
    public string speciesName {get; set;}
    //public string rarity {get; set;}
    public int numSeen {get; set;}
    public Bird() {}
    /*
    public Bird(string _bandCode, int _numSeen)
    {
        speciesID = Guid.NewGuid(); 
        bandCode = _bandCode;
        numSeen = _numSeen;
    }
    public Bird(string _bandCode, int _numSeen, string _speciesName)
    {
        speciesID = Guid.NewGuid(); 
        bandCode = _bandCode;
        speciesName = _speciesName;
        numSeen = _numSeen;
    }
    */
    public Bird(string _bandCode, string _speciesName, string _rarity)
    {
        //speciesID = Guid.NewGuid(); 
        bandCode = _bandCode;
        speciesName = _speciesName;
        rarity = _rarity;
    }
}