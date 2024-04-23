namespace IntroClass;

public class Dog
{
    //A class will have members, which are fields/variables and methods

    //Fields
    //Should include access modifiers -- public, protected, internal, private, and less commonly, private internal and private protected
    /*
    public: access is unrestricted
    private: access is only from within the type
    internal: access is only from within the current assembly (groups of .cs files)
    protected: access is limited to this class or classes that inherit from the current class; this essentially forces the programmer to behave in a certain way
    private internal: access is limited to the current assembly or types derived from containing class
    private protected: access is limited to the containing class or types derived from the containing class within the current assembly

    If something is not given an access modifier, the default is internal
    */
    //classes and methods also have access modifiers


    public string name {get; set;}
    public string breed {get; set;}
    public int age {get; set;}
    public string gender {get; set;}
    public double weight {get; set;}

    //Methods
    //An instance method can be called via dot notation from an instance of the class
    public void Bark()
    {
        Console.WriteLine($"{name}: Bark");
    }
}