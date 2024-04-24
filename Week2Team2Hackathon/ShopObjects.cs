namespace Week2Team2Hackathon;
using System;
using System.Collections;

using System.IO;

class oldShopObjects
{
    private string brandName {get; set;}
    private string productName {get; set;}
    private string dept {get; set;}
    private int aisle {get; set;}
    private int stock {get; set;}
    private int itemID {get; set;}

    private void WriteStock()
    {
        Console.WriteLine($"{itemID}: {brandName} {productName}; {stock} on hand");
    }
    public oldShopObjects(){}

    public oldShopObjects (int itemID, string brandName, string productName, int stock)
    {
        this.itemID = itemID;
        this.brandName = brandName;
        this.productName = productName;
        this.stock = stock;
    }

/*
    public IEnumerator<ShopObjects> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        yield return ShopObjects[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
*/
}