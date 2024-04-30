namespace Project01;

class Product
{
    public string brandName {get; set;}
    public string productName {get; set;}
    public string dept {get; set;}
    public int stock {get; set;}
    public int itemID {get; set;}

    public void WriteStock()
    {
        Console.WriteLine($"{itemID}: {brandName} {productName}; {stock} on hand");
    }
    public Product(){}

    public Product (int itemID, string dept, string brandName, string productName, int stock)
    {
        this.itemID = itemID;
        this.dept = dept;
        this.brandName = brandName;
        this.productName = productName;
        this.stock = stock;
    }
}
class Camera : Product
{
    public float resolution {get; set;}
    public bool interchangeableLens {get; set;}
    public string lensMount {get; set;}
    public bool viewfinder {get; set;}
    public float screenResolution {get; set;}

}

class Lens : Product
{

}

class Lighting : Product
{

}
class Modifiers : Product
{

}