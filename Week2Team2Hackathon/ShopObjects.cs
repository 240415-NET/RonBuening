namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;
using System.IO;

class ShopObjects
{
    public string BrandName {get; set;}
    public string ProductName {get; set;}
    public string dept {get; set;}
    public int aisle {get; set;}
    public int stock {get; set;}

    public void WriteStock()
    {
        Console.WriteLine($"{dept} has {stock} of {BrandName} {ProductName} in aisle {aisle}");
    }

}