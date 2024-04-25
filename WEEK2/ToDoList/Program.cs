namespace ToDoList;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        //ToDoItem toDo = new ToDoItem{"Buy hat",45,"2024-04-25",false};
        ToDoItem toDo = new ToDoItem();
        Console.WriteLine(toDo);
        ToDoItem toDo2 = new ToDoItem("Get milk",60,"2024-04-25",false);
        Console.WriteLine(toDo2);
        Console.Clear();
        Console.WriteLine("Type Description:");
        string description = Console.ReadLine();
        Console.WriteLine("Estimated Time:");
        int estimatedTime = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Due Date:");
        string dueDate = Console.ReadLine();
        ToDoItem toDo3 = new ToDoItem(description,estimatedTime,dueDate,false);
        Console.WriteLine(toDo3);
    }
}
