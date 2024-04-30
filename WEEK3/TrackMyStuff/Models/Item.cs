namespace TrackMyStuff.Models;

public class Item
{
    internal int itemID {get; set;}
    internal int userID {get; set;}
    internal string category {get; set;}
    internal double originalCost {get; set;}
    internal DateTime purchaseDate {get; set;}
    internal string description {get; set;}
    
}