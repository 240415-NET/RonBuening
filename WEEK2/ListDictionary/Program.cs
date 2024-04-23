namespace ListDictionary;

class Program
{
    static void Main(string[] args)
    {
        //Lists store a variable type in an array-like structure. Unlike arrays, the lists do not have a fixed length; they're dynamically sized. Duplicate values can be contained within them.
        List<string> cityList = new List<string>();

        cityList.Add("Miami");
        cityList.Add("Tampa");
        cityList.Add("Sarasota");
        cityList.Add("Chicago");
        cityList.Add("Clearwater");

        foreach(string city in cityList)
        {
            Console.WriteLine(city);
        }

        //Dictionary is a dynamically sized collection that holds key-value pairs
        //Keys must be unique and may be of any type so long as it fits the type of the Dictionary
        //"new List<string>();" and "new();" are exactly the same when defining Lists (and Dictionaries)

        Dictionary<string,List<string>> petDictionary = new();

        //This is an example of nesting collections. Not only can Dictionaries contain lists, but other Dictionaries as well.
        
        petDictionary.Add("Jonathan", new List<string>(){"Pancake","Ellie"});
        petDictionary.Add("Ross",new List<string>(){"Brody"});
        petDictionary.Add("Mike",new List<string>(){"Carl"});
        petDictionary.Add("Marcus",new List<string>(){"Ziggy","Luna","Amelia","Pyewhacket","Love"});

        List<string> jonPets = new List<string>(){"Ellie","Pancake"};

        foreach(var owner in petDictionary)
        {
            for (int i = 0; i < owner.Value.Count(); i++)
            {
                Console.WriteLine($"{owner.Key} owns {owner.Value[i]}");  
            }  
        }
        

        Dictionary<string,string> simplePets = new();
        simplePets.Add("Jonathan","Ellie");
        simplePets.Add("Ross","Brodie");
        simplePets.Add("Mike","Carl");
        simplePets.Add("Marcus","Ziggy");
        /*
        //The use of var here is an example of implicit typing in C#
        foreach (var owner in simplePets)
        {
            Console.WriteLine(owner);
            //Console.WriteLine(owner.GetType());
            Console.WriteLine(owner.Key + " owns " + owner.Value);
        }
        */
    }
}
