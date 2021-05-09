using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    // User repo
    public interface IUserRepository
    {
        //methods for user class
        // crud related method 

        int InsertUser(User user);
        int UpdateUserDetails(User user);
        int UpdateUserPassword(User user);
        int DeleteUser(int userId);
        List<User> GetUser(); // to fetch all users
        List<User> GetUserByUserID(int userId); //to get user by id 

        //question email is present in seprate table so how we get user based 
        //on email and we dont have user ref in email table 
        List<User> GetUserByEmail(string Email); // ajax call for database to chk email is present in db or not 
        List<User> GetUserByEmailAndPassword(string Email, string Password);
        List<User> GetUsersByRoleId(int roleId);
        string[] GetRolesForUser(string username);
    }
}
