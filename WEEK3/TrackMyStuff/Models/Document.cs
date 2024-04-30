namespace TrackMyStuff.Models;

public class Document : Item
{
    internal string documentType {get; set;}
    internal DateTime expiration {get; set;}
}