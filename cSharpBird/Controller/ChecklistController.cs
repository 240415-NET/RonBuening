namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class ChecklistController
{
    public static IAccessChecklistFile AccessChecklistFile = new AccessChecklistFileJson
    public static List<Checklist> GetLists(User searchUser)
    {
        AccessChecklistFile.GetLists(searchUser);
        return userChecklists;
    }
    public static void WriteChecklist(Checklist newList)
    {
        AccessChecklistFile.WriteChecklist(newList);
    }
    public static void WriteUpdatedList(Checklist updatedList)
    {
        AccessChecklistFile.WriteUpdatedList(updatedList);
    }
}