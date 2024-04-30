namespace TrackMyStuff.Models;

public class Document : Item
{
    string documentType {get; set;}
    DateTime expiration {get; set;}
}