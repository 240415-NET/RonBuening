﻿using ClassBasics.Classes;

namespace ClassBasics
{
    public class ClassBasics
    {
        public static void Main(string[] args)
        {
            ExampleClass exampleClass = new ExampleClass {Age = 30}; //Declaration
            
            exampleClass = new ExampleClass() //Setting through instantiation

            

            // exampleClass.Name = "    Hello   "; // this will not compile as we are accessing a private variable
/*
            exampleClass.SetName("   Hello         ");
            Console.WriteLine(exampleClass.GetName());

            exampleClass.Age = 55; // this is fine because the Age field is public

            Console.WriteLine(exampleClass.GetMaxLimit());
*/
            Person personA = new Person();

            Console.WriteLine(personA.GetFirstName());
            Console.WriteLine(personA.GetLastName());
            Console.WriteLine(personA.GetEmail());
            Console.WriteLine(personA.GetAge());
            Console.WriteLine(personA.GetOnHoliday);

            Person personB = new Person();
            personB.SetFirstName("Brian");
            personB.SetLastName("Arayathel");
            personB.SetEmail("brian.arayathe@revature.com");
            personB.SetAge(25);
            personB.SetOnHoliday(false);

            Console.WriteLine(personB.GetFirstName());
            Console.WriteLine(personB.GetLastName());
            Console.WriteLine(personB.GetEmail());
            Console.WriteLine(personB.GetAge());
            Console.WriteLine(personB.GetOnHoliday);
        }
    }

}