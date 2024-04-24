namespace ToDoList;

class ToDoItem
{
    private string description = "Default";
    private bool status = false;
    private int estTime = 60; //implemented as minutes
    private string dueDate = "2024-04-24";

    public string GetDescription(){
        return this.description;
    }

    public void SetDescription(){
        this.description = description;
    }
    public bool GetStatus(){
        return status;
    }
    public void SetStatus(){
        this.status = status;
    }
    public int GetEstTime(){
        return estTime;
    }
    public void SetEstTime(){
        this.estTime = estTime
    }
    public string GetDueDate(){
        return dueDate;
    }
    public void SetDueDate(){
        this.dueDate = dueDate;
    }

}
