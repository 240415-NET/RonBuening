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

    public Product (int itemID, string dept, string brandName, string productName)
    {
        this.itemID = itemID;
        this.dept = dept;
        this.brandName = brandName;
        this.productName = productName;
        this.stock = 0;
    }
}
class Camera : Product
{
    public float resolution {get; set;}
    public bool interchangeableLens {get; set;}
    public string lensMountReceive {get; set;}
    public bool viewfinder {get; set;}
    public float screenResolution {get; set;}

}

class Lens : Product
{
    public bool zoom {get; set;}
    public int minFocalLength {get; set;}
    public int maxFocalLength {get; set;}
    public int minAperture {get; set;}
    public int maxAperture {get; set;}
    public string lensMount {get; set;}
}

class Lighting : Product
{
    public bool wallPower {get; set;}
    public bool flash {get; set;}
    public int wattSecond {get; set;}
    public int guideNumber {get; set;}
    public string modifierMountReceive {get; set;}
}
class Modifiers : Product
{
    public string modifierType {get; set;}
    public string modifierMount {get; set;}
    public int modifierHeight {get; set;}
    public int modifierWidth {get; set;}
}