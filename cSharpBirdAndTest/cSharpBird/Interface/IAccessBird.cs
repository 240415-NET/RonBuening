namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public interface IAccessBird
{
    public List<Bird> GetFullBirdList();
    public void WriteBirdsForChecklist(Checklist checklist);
    public List<Bird> ReadBirdsForChecklist(Checklist checklist);
}