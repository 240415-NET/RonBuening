namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class Checklist
{
    public Guid checklistID {get; set;}
    public Guid userId {get;set;}
    public string locationName {get; set;}
    public DateTime checklistDateTime {get; set;}
    public List<Bird> birdChecklist {get; set;}
    public string birder {get; set;}
    public Checklist() {}

    public Checklist(Guid _userId, string _locationName)
    {
        checklistID = Guid.NewGuid();
        userId = _userId;
        locationName = _locationName;
        checklistDateTime = DateTime.Today;
        List<Bird> birdChecklist = new List<Bird>();
    }
    public Checklist(Guid _userId, string _locationName, string _checklistDateTime)
    {
        checklistID = Guid.NewGuid();
        userId = _userId;
        locationName = _locationName;
        checklistDateTime = DateTime.Parse(_checklistDateTime);
        List<Bird> birdChecklist = new List<Bird>();
    }
}