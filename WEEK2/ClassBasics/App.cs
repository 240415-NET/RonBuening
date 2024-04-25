using System.Runtime.InteropServices;

namespace ClassBasics
{
    public class App
    {
        public static void Main(string[] args)
        {
            App.PillarsExample();
        }

        public static void PillarsExample()
        {
            /*
                Polymophism
                --Allows methods to do different things based on the object that is acting upon them
                --This can be achieved by method overriding
                    --A child class can provide their own specific implementation of a method already provided by one of its parent classes
                    --i.e. overriding the ToString() method
                --Can be achieved by method overloading
                    --Where multiple methods can have the same name but different parameters or order of parameters
                        --Requires a unique method signature (return_type method_name(parameters))
                        --The name is consistent, but parameters are different 
            */
            PolymophismExample polymophismExample = new PolymophismExample();
            Console.WriteLine(polymophismExample.Add(1,2));
            Console.WriteLine(polymophismExample.Add(1.5f,2.23432f));
            Console.WriteLine(polymophismExample.Add(long.MaxValue/2,long.MinValue));
            Console.WriteLine(polymophismExample);

            /*
                Inheritance
                --Allows a class to inherit attributes and methods from another class
                --The class that inherits is called the subclass, derived class, or child class
                --The class that is inherited from is called the superclass, base class, or parent class
                --Inheritance enforces a hierarchical structure to objects and classes
                --i.e. Class A -> Class B -> Class C -> Class D
                    --Class D will have all aspects of preceeding classes
                    --Class A will only have its own aspects
            */
            Animal animal = new Animal("Monkey","Ooh ooh, aah aah");
            Dog lassie = new Dog(42,false); //will use default name based on constructor
            Dog pancake = new Dog("Pancake",30,false,"Ugh");
            GermanShepherd hans = new GermanShepherd("Hans",35,true,true,2);
            animal.Speak();
            lassie.Speak();
            pancake.Speak();
            hans.Speak();


        }

        public class PolymophismExample()
        {
            public int Add(int a,int b)
            {
                return a + b;
            }
            public float Add(float a, float b)
            {
                return a + b;
            }
            public long Add(long a, long b)
            {
                return a + b;
            }
            public override string ToString()
            {
                return $"Polymorphism Example Overriding method";
            }
        }

        //Inheritance Examples

        public class Animal
        {
            public string Name {get; set;}
            public string speech {get; set;}
            public Animal(string Name, string speech)
            {
                this.Name = Name;
                this.speech = speech;
            }
            public virtual void Speak()
            {
                Console.WriteLine($"{Name} says {speech}");
            }

        }
        public class Dog : Animal //Inherits from Animal, sibling class of Cat
        {
            public int TeethCount {get;set;}
            public bool isDomesticated {get;set;}
            
            //inherits Name from animal, defines TeethCount and isDomesticated internally
            public Dog (string Name, int TeethCount, bool isDomesticated, string speech) : base(Name,speech)
            {
                this.TeethCount = TeethCount;
                this.isDomesticated = isDomesticated;
            }
            //this will route a default name
            public Dog (int TeethCount, bool isDomesticated) : base("Lassie","Timmy is down the well")
            {
                this.TeethCount = TeethCount;
                this.isDomesticated = isDomesticated;
            }
            //overriding parent method, will also override for children unless overridden there
            public override void Speak()
            {
                //below was automatically added
                //base.Speak();
                Console.WriteLine($"Dog with name {Name} says {speech}");
            }
        }
        /*
        public class Cat : Animal //Inherits from Animal, sibling class of Dog
        {
            public Cat (string Name) : base(Name){}
        }
        */
        public class GermanShepherd : Dog //Inherits from Dog, subclass of both Dog and Animal
        {
            //inherits all attributes from Dog and can have additional attributes added
            public bool hasFullTail = true;
            public int dogShowWins = 0;
            public GermanShepherd (string Name, int TeethCount, bool isDomesticated, bool hasFullTail, int dogShowWins) : base(Name, TeethCount, isDomesticated, "Bark Bark")
            {
                this.hasFullTail = hasFullTail;
                this.dogShowWins = dogShowWins;
            }
            public override void Speak()
            {
                Console.WriteLine($"German Shepherd {Name}: {speech}");
            }
        }
    }
}