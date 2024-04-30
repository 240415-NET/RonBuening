namespace TrackMyStuff.Models;

public class Item
{
    int itemID {get; set;}
    int userID {get; set;}
    string category {get; set;}
    double originalCost {get; set;}
    DateTime purchaseDate {get; set;}
    string description {get; set;}
    
}