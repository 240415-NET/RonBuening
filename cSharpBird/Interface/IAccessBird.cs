namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public interface IAccessBird
{
    public List<Bird> GetFullBirdList();
}