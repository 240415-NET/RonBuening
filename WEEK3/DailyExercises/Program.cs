namespace DailyExercises;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        //for (int i = 2; i <= N; i+=2)
        //{
        //    Console.WriteLine(i);
        //}

        int i = 0;
        int k = 0;

        do
        {
            k+=i;
            i+=2;
        }
        while (i <= N);

        Console.WriteLine(k);
    }
     interface IEmployee
        {
            string Name
            {
                get;
                set;
            }

            int Counter
            {
                get;
            }
        }

        public class Employee : IEmployee
        {
            public static int numberOfEmployees;

            private string _name;
            public string Name  // read-write instance property
            {
                get => _name;
                set => _name = value;
            }

            private int _counter;
            public int Counter  // read-only instance property
            {
                get => _counter;
            }

            // constructor
            public Employee() => _counter = ++numberOfEmployees;
        }
}
