using System;
using System.Collections.Generic;
using System.Linq;
using OOP_CourseProject_Fitness.Models;

public class AuthenticationService
{

    public static bool Register(string username, string password, string role)
    {
      
        var users = new JsonDataService().LoadData<User>(); 
        if (users.Any(u => u.Username == username))
        {
            return false;
        }

        var newUser = new User
        {
            ID = users.Count + 1,
            Username = username,
            Password = password, 
            Role = role
        };

        users.Add(newUser);

       
        new JsonDataService().SaveData(users); 
        return true;
    }


    public static User Login(string username, string password)
    {
        
        var users = new JsonDataService().LoadData<User>(); 
        return users.FirstOrDefault(u => u.Username == username && u.Password == password); 
    }
}
