namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class BirdController
{
    public static IAccessBird AccessBird = new AccessBirdCSV();
    public static List<Bird> GetFullBirdList()
    {
        List<Bird> birdList = AccessBird.GetFullBirdList();
        return birdList;
    }
    public static void WriteBirdsForChecklist (Checklist checklist)
    {
        AccessBird.WriteBirdsForChecklist(checklist);
    }
    public static List<Bird> ReadBirdsForChecklist (Checklist checklist)
    {
        List<Bird> birdList = AccessBird.ReadBirdsForChecklist(checklist);
        return birdList;
    }
}