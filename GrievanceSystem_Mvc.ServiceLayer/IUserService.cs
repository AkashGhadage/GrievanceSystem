using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public interface IUserService
    {

        //methods for user class
        // crud related method 

        int InsertUser(RegisterViewModel user);
        int UpdateUserDetails(EditUserViewModel user);
        int UpdateUserPassword(EditUserPasswordViewModel user);
        int DeleteUser(int userId);
        List<UserViewModel> GetUser(); // to fetch all users

        UserViewModel GetUserByUserID(int userId); //to get user by id 

        //question email is present in seprate table so how we get user based 
        //on email and we dont have user ref in email table 
        UserViewModel GetUserByEmail(string Email);// ajax call for database to chk email is present in db or not 
        UserViewModel GetUserByEmailAndPassword(string Email, string Password);
        List<UserViewModel> GetUsersByRoleId(int roleId);
        String[] GetRolesForUser(string username);
    }
}
