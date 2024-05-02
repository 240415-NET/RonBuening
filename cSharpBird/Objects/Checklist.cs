namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class Checklist
{
    public Guid checklistID {get; set;}
    public string locationName {get; set;}
    public DateTime checklistDateTime {get; set;}
    public List<Bird> birdChecklist {get; set;}
    public string birder {get; set;}
    public Checklist() {}

    public Checklist(string _birder, string _locationName)
    {
        checklistID = Guid.NewGuid();
        birder = _birder;
        locationName = _locationName;
        checklistDateTime = DateTime.Today;
        List<Bird> birdChecklist = new List<Bird>();
    }
    public Checklist(string _birder, string _locationName, string _checklistDateTime)
    {
        checklistID = Guid.NewGuid();
        birder = _birder;
        locationName = _locationName;
        checklistDateTime = DateTime.Parse(_checklistDateTime);
        List<Bird> birdChecklist = new List<Bird>();
    }
}