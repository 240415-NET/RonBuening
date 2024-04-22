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

        for (int i = 0; i < student_grades.Length; i++)
        {
            Console.WriteLine(student_grades[i]);
        }

        //an enhanced for loop is available as a shorthand
        foreach (int grade in student_grades2)
        {
            Console.WriteLine(grade);
        }
    }
}
