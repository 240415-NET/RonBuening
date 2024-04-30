namespace TrackMyStuff.Models;

public class Document : Item
{
    public string documentType {get; set;}
    public DateTime expiration {get; set;}
}