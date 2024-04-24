namespace ToDoList;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        ToDoItem toDo = new ToDoItem{"Buy hat",45,"2024-04-25",false};
        Console.Write(toDo);
    }
}
