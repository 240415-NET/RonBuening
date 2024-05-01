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
    public Guid itemID {get; set;}

    public void WriteStock()
    {
        Console.WriteLine($"{itemID}: {brandName} {productName}; {stock} on hand");
    }
    public Product(){}

    public Product (string dept, string brandName, string productName, int stock)
    {
        this.itemID = Guid.NewGuid();
        this.dept = dept;
        this.brandName = brandName;
        this.productName = productName;
        this.stock = stock;
    }

    public Product (string dept, string brandName, string productName)
    {
        this.itemID = Guid.NewGuid();
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
    public Camera (string dept, string brandName, string productName, float resolution, bool interchangeableLens, string lensMountReceive, bool viewfinder, float screenResolution) :base (dept, brandName, productName)
    {
        this.itemID = Guid.NewGuid();
        this.dept = dept;
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
    public Lens (string dept, string brandName, string productName, bool zoom, int minFocalLength, int maxFocalLength, int minAperture, int maxAperture, string lensMount) :base (dept, brandName, productName)
    {
        this.itemID = Guid.NewGuid();
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
    public Lighting (string dept, string brandName, string productName, bool wallPower, bool flash, int wattSecond, string modifierMountReceive) :base (dept, brandName, productName)
    {
        this.itemID = Guid.NewGuid();
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
    public Modifiers (string dept, string brandName, string productName, string modifierType, string modifierMount, int modifierHeight, int modifierWidth) :base (dept, brandName, productName)
    {
        this.itemID = Guid.NewGuid();
        this.dept = "Modifiers";
        this.brandName = brandName;
        this.productName = productName;
        this.modifierType = modifierType;
        this.modifierMount = modifierMount;
        this.modifierHeight = modifierHeight;
        this.modifierWidth = modifierWidth;
    }
}