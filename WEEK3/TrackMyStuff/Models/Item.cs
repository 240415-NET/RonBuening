namespace TrackMyStuff.Models;

public class Item
{
    public int itemID {get; private set;}
    public int userID {get; private set;}
    public string category {get; set;}
    public double originalCost {get; set;}
    public DateTime purchaseDate {get; set;}
    public string description {get; set;}

    public Item () {}
    public Item (int itemID, int userId, string category, double originalCost, DateTime purchaseDate, string description)
    {
        this.itemID = itemID;
        this.userID = userID;
        this.category = category;
        this.originalCost = originalCost;
        this.purchaseDate = purchaseDate;
        this.description = description;
    }
    
}