namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public interface IAccessUserFile
{
    public List<User> GetFullUserList();

    public void WriteUser(User user);

    public void WriteUpdatedUser(User updatedUser);

    public void WriteCurrentUser(User user);

    public User ReadCurrentUser();

    public void ClearCurrentUser();
}