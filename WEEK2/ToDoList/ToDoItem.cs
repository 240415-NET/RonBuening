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
        this.estTime = estTime
    }
    public string GetDueDate(){
        return dueDate;
    }
    public void SetDueDate(string dueDate){
        this.dueDate = dueDate;
    }

    public override string ToString(){
        return base.ToString();
    }

}
