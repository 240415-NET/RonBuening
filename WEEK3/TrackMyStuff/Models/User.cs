namespace TrackMyStuff.Models;

public class User
{
    //Fields

    //You can leverage get; set; shorthand to protect fields by putting a different access modified to the getter or setter
    public int userId {get; private set;}
    public string userName {get; set;}
    //private string password {get; set;}

    //Constructors
    public User() {}
    public User (int _userId, string _userName)
    {
        userId = _userId;
        userName = _userName;
    }
    /*public User (int _userId, string _userName, string _password)
    {
        userId = _userId;
        userName = _userName;
        password = _password;
    }*/

}