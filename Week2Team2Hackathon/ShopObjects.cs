namespace Week2Team2Hackathon;
using System;
using System.Collections;
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
        Console.WriteLine($"{itemID}: {brandName} {productName}; {stock} on hand");
    }
    public ShopObjects(){}

    public ShopObjects (int itemID, string brandName, string productName, int stock)
    {
        this.itemID = itemID;
        this.brandName = brandName;
        this.productName = productName;
        this.stock = stock;
    }
}
/*
class Nikon : ShopObjects
{
    public Nikon(){}
    public Nikon (int itemID, string productName, int stock) : base()
}
*/