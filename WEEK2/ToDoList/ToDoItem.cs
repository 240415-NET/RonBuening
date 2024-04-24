namespace ToDoList;
using System.Collections;

class ToDoItem
{
    private string description = "Default";
    private bool status = false;
    private int estTime = 60; //implemented as minutes
    private string dueDate = "2024-04-24";

    public string GetDescription(){
        return this.description;
    }

    public void SetDescription(string description){
        this.description = description;
    }
    public bool GetStatus(){
        return status;
    }
    public void SetStatus(bool status){
        this.status = status;
    }
    public int GetEstTime(){
        return estTime;
    }
    public void SetEstTime(int estTime){
        this.estTime = estTime;
    }
    public string GetDueDate(){
        return dueDate;
    }
    public void SetDueDate(string dueDate){
        this.dueDate = dueDate;
    }
    public ToDoItem(string description, int estTime, string dueDate, bool status){
        this.description = description;
        this.estTime = estTime;
        this.dueDate = dueDate;
        this.status = status;
    }

    public override string ToString(){
        string CurrentStatus = "Incomplete";
        //this avoids a raw boolean in the two string, changing it based on an if statement after defaulting to false
        if (status){
            CurrentStatus = "Complete";
        }
        return $"{description} - {dueDate}\nEstimated Time: {estTime}\nStatus: {CurrentStatus}";
    }

}
