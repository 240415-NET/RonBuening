using System.Runtime.InteropServices;

namespace ClassBasics.TodoList
{
    public class TodoItem
    {

        // These are the fields that will make up the shape of my object
        private string Description = "Default Description";
        private int EstimatedTime = 60; // int as minutes

        private string DueDate = "4/24/2024";

        private bool Status = false; // false is incomplete

        //This is the default constructor that any class will use by default
        //If you include your own constructor, there will not be a default constructor unless explicitly added
        //When created by the developer, this can be called a No-Args constructor.
        public TodoItem(){

        }
        //Any of these constructors can be called to create the object, but only one will be used at a time.
        public TodoItem(string Description, int EstimatedTime, string DueDate, bool Status) : this(Description, EstimatedTime, DueDate) //the ': this(yadayada)' passes those items to a different constructor as a short hand.
        {
            //this.Description = Description;
            //this.EstimatedTime = EstimatedTime;
            //this.DueDate = DueDate;
            this.Status = Status;
        }

        //this is an example of constructor overloading
        public TodoItem(string Description, int EstimatedTime, string DueDate) : this (Description,EstimatedTime)
        {
            //this.Description = Description;
            //this.EstimatedTime = EstimatedTime;
            this.DueDate = DueDate;
        }

         public TodoItem(string Description, int EstimatedTime)
        {
            this.Description = Description;
            this.EstimatedTime = EstimatedTime;
            this.DueDate = $"{DateTime.Now}";
        }

        // My methods are how I will interact with the objects, and how the objects will interact with each other
        public string GetDescription(){
            return this.Description;
        }

        public void SetDescription(string Description){
            this.Description = Description;
        }

        public bool GetStatus(){
            return this.Status;
        }

        public void SetStatus(bool Status){
            this.Status = Status;
        }

        public int GetEstimatedTime(){
            return this.EstimatedTime;
        }

        public void SetEstimatedTime(int EstimatedTime){
            this.EstimatedTime = EstimatedTime;
        }

        public string GetDueDate(){
            return this.DueDate;
        }

        public void SetDueDate(string DueDate){
            this.DueDate = DueDate;
        }


        // Override the ToString

        public override string ToString()
        {
            // I do not want to put a raw boolean inside my ToString, so I have created my own string representing the status of the boolean
            // It will default to false, showing incomplete
            string CurrentStatus = "Incomplete";


            // If the todo Item field Status is set to be true, then this If statement will evaluate
            // And update the CurrentStatus string to "Complete"
            if(Status){
                CurrentStatus = "Complete";
            }

            return $"{Description} - {DueDate}\nEstimated Time: {EstimatedTime}\nStatus: {CurrentStatus}";
        }

/*
        public static void Main(string[] args){

            // TodoItem item1 = new TodoItem();

            // Console.WriteLine(item1);

            // TodoItem item2 = new TodoItem("Get Milk", 60, "4/25/2024", false);

            // Console.WriteLine(item2);


            List<TodoItem> todoItems = new List<TodoItem>();

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Type Description:");

                string description = Console.ReadLine();

                Console.WriteLine("Estimated Time:");

                int estimatedTime = int.Parse(Console.ReadLine());

                Console.WriteLine("Due Date:");

                string dueDate = Console.ReadLine();

                TodoItem newItem = new TodoItem(description, estimatedTime, dueDate, false);

                todoItems.Add(newItem);
            }


            foreach(var item in todoItems){
                Console.WriteLine(item);
            }

            // Organizing my UI into a class
            // Adding validation and checks for userinput and saving to my object
            // Adding a way to add items individually, instead of 6 at a time
            // etc

        }*/
    }
}