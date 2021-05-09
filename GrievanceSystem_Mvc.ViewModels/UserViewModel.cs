using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrievanceSystem_Mvc.ViewModels
{
    // used to view user  --> admin can view user 
    public class UserViewModel
    {

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string EmailAddress { get; set; }

        //added later 
        public string Password { get; set; }

        public string Role { get; set; }
    }

}
