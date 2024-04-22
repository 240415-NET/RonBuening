namespace StringArray;

class Program
{
    static void Main(string[] args)
    {
        int student_one_grade = 97;
        int student_two_grade = 93;
        int student_three_grade = 100;
        int student_four_grade = 85;

        int[] student_grades = new int[4];

        //arrays are contiguous data structures, may only have a single data type assigned, and have fixed length in memory
        //all arrays start counting from 0 to i-1 where i is the length of the array

        //individual initialization
        student_grades[0] = 97;
        student_grades[1] = 93;
        student_grades[2] = 100;
        student_grades[3] = 85;

        //easy initialization, declaring and intializing in one line
        int[] student_grades2 = {97,93,100,85};

        //to access the values in the array, you cannot simply refer to array
        //can use for loop
        /*
        for (int i = 0; i < student_grades.Length; i++)
        {
            Console.WriteLine(student_grades[i]);
        }

        //an enhanced for loop is available as a shorthand
        foreach (int grade in student_grades2)
        {
            Console.WriteLine(grade);
        }
        */

        //a string is an array of chars
        char[] hello_chars = {'H','e','l','l','o'};
        string hello_string = new string(hello_chars);
        Console.WriteLine(hello_chars);
        Console.WriteLine(hello_string);

        //.ToCharArray() method converts strings to an array of chars
        string world_string = "world!";
        char[] world_chars = world_string.ToCharArray();

        Console.WriteLine(world_string);
        Console.WriteLine(world_chars);

        //The big difference is that since the string is also considered an object, it can also be used with methods (AKA functions). 

        //String methods
        string new_word = Console.ReadLine();
        Console.WriteLine(new_word);
        new_word = new_word.ToUpper();
        Console.WriteLine(new_word);
        Console.WriteLine(new_word.ToLower());

        foreach (char c in new_word)
        {
            Console.WriteLine(c);
        }

        for (int i = 1; i < new_word.Count(); i++)
        {
            Console.WriteLine(new_word[i]);
        }

        Console.WriteLine(new_word.Substring(new_word.Count()-3,3));

        //Remember that references (the variable names) can refer to the same data (the values), but that the data is immutable in a string.

        //Contains is a method that returns a booolean based on the contents of a string or substring

        Console.WriteLine("Please write your name");
        string name = Console.ReadLine();

        Console.WriteLine(name.Contains("mike"));

        if (name.ToLower().Contains("Mike"))
        {
            Console.WriteLine("Hello Mike!");
        }
        else
        {
            Console.WriteLine("Hello " + name + '!');
        }

    }
}
