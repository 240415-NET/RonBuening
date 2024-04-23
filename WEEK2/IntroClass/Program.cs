namespace IntroClass;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Dog pancake = new Dog();

        pancake.name = "Pancake";

        pancake.Bark();
        Dog.DefineDog();
    }
}
