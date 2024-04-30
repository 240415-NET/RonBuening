namespace TrackMyStuff.Models;

public class User
{
    //Fields

    //You can leverage get; set; shorthand to protect fields by putting a different access modified to the getter or setter
    public int userId {get; private set;}
    public string userName {get; set;}

    //Constructors
    public User() {}
    public User (int _userId, string _userName)
    {
        userId = _userId;
        userName = _userName;
    }

}