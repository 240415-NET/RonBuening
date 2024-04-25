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
                -- Allows methods to do different things based on the object that is acting upon them
                -- This can be achieved by method overriding
                    --A child class can provide their own specific implementation of a method already provided by one of its parent classes
                    -- i.e. overriding the ToString() method
                -- Can be achieved by method overloading
                    -- Where multiple methods can have the same name but different parameters or order of parameters
                        -- Requires a unique method signature (return_type method_name(parameters))
                        -- The name is consistent, but parameters are different 
            */
            PolymophismExample polymophismExample = new PolymophismExample();
            Console.WriteLine(polymophismExample.Add(1,2));
            Console.WriteLine(polymophismExample.Add(1.5f,2.23432f));
            Console.WriteLine(polymophismExample.Add(long.MaxValue/2,long.MinValue));
            Console.WriteLine(polymophismExample);
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
    }
}