namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;
public class Product
{
    public string brandName {get; set;}
    public string productName {get; set;}
    public string dept {get; set;}
    public int? stock {get; set;}
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
public class Camera : Product
{
    public float resolution {get; set;}
    public bool interchangeableLens {get; set;}
    public string lensMountReceive {get; set;}
    public bool? viewfinder {get; set;}
    public float? screenResolution {get; set;}
    public Camera () {}
    public Camera (int itemID, string dept, string brandName, string productName, float resolution, bool interchangeableLens, string lensMountReceive, bool viewfinder, float screenResolution) :base Product(itemID, dept, brandName, productName)
    {
        this.itemID = itemID;
        this.dept = "Camera";
        this.brandName = brandName;
        this.productName = productName;
        this.resolution = resolution;
        this.interchangeableLens = interchangeableLens;
        this.lensMountReceive = lensMountReceive;
        this.viewfinder = viewfinder;
        this.screenResolution = screenResolution;
    }

}

public class Lens : Product
{
    public bool zoom {get; set;}
    public int minFocalLength {get; set;}
    public int maxFocalLength {get; set;}
    public int? minAperture {get; set;}
    public int? maxAperture {get; set;}
    public string lensMount {get; set;}
    public Lens () {}
    public Lens (int itemID, string dept, string brandName, string productName, bool zoom, int minFocalLength, int maxFocalLength, int minAperture, int maxAperture, string lensMount) :base Product (itemID, dept, brandName, productName)
    {
        this.itemID = itemID;
        this.dept = "Lens";
        this.brandName = brandName;
        this.productName = productName;
        this.zoom = zoom;
        this.minFocalLength = minFocalLength;
        this.maxFocalLength = maxFocalLength;
        this.minAperture = minAperture;
        this.maxAperture = maxAperture;
        this.lensMount = lensMount;
    }
}

public class Lighting : Product
{
    public bool wallPower {get; set;}
    public bool flash {get; set;}
    public int? wattSecond {get; set;}
    public string? modifierMountReceive {get; set;}
    public Lighting () {}
    public Lighting (int itemID, string dept, string brandName, string productName, bool wallPower, bool flash, int wattSecond, string modifierMountReceive) :base Product (itemID, dept, brandName, productName)
    {
        this.itemID = itemID;
        this.dept = "Lighting";
        this.brandName = brandName;
        this.productName = productName;
        this.wallPower = wallPower;
        this.flash = flash;
        this.wattSecond = wattSecond;
        this.modifierMountReceive = modifierMountReceive;
    }
}
public class Modifiers : Product
{
    public string modifierType {get; set;}
    public string modifierMount {get; set;}
    public int? modifierHeight {get; set;}
    public int? modifierWidth {get; set;}
    public Modifiers () {}
    public Modifiers (int itemID, string dept, string brandName, string productName, string modifierType, string modifierMount, int modifierHeight, int modifierWidth) :base Product (itemID, dept, brandName, productName)
    {
        this.itemID = itemID;
        this.dept = "Modifiers";
        this.brandName = brandName;
        this.productName = productName;
        this.modifierType = modifierType;
        this.modifierMount = modifierMount;
        this.modifierHeight = modifierHeight;
        this.modifierWidth = modifierWidth;
    }
}