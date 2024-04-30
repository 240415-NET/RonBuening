namespace TrackMyStuff.Models;

public class Pet : Item
{
    public string name {get; set;}
    //a question mark after the type results in a nullable item
    public string? species {get; set;}
    public int? age {get; set;}

    public Pet (int itemID, int userId, string category, double originalCost, DateTime purchaseDate, string description, string name, string species, int age) :base Item(itemID, userId, category, originalCost, purchaseDate, description)
    {
        this.name = name;
        this.species = species;
        this.age = age;
    }
}