namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class BirdController
{
    public static IAccessBird AccessBird = new AccessBirdCSV();
    public static List<Bird> GetFullBirdList()
    {
        //for checklist file creation, calls interface to retrieve for csv
        List<Bird> birdList = AccessBird.GetFullBirdList();
        return birdList;
    }
    public static void WriteBirdsForChecklist (Checklist checklist)
    {
        //currently unusued
        AccessBird.WriteBirdsForChecklist(checklist);
    }
    public static void UpdateBirdsForChecklist (Checklist checklist)
    {
        //currently unusued
        AccessBird.UpdateBirdsForChecklist(checklist);
    }
    public static List<Bird> ReadBirdsForChecklist (Guid checklistID)
    {
        //currently unused
        List<Bird> birdList = AccessBird.ReadBirdsForChecklist(checklistID);
        return birdList;
    }
}