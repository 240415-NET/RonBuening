namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;
using System.IO;

class ShopObjects
{
    public string brandName {get; set;}
    public string productName {get; set;}
    public string dept {get; set;}
    public int aisle {get; set;}
    public int stock {get; set;}
    public int itemID {get; set;}

    public void WriteStock()
    {
        Console.WriteLine($"{dept} has {stock} of {brandName} {productName} in aisle {aisle}");
    }

}