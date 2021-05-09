using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrievanceSystem_Mvc.ViewModels
{
    // RegisterViewModel for Student only 
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "* First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "* Middle Name is required")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "* Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "* Mobile Number is required")]
        [RegularExpression(@"^(\+\d{1, 3}[- ]?)?\d{10}$", ErrorMessage = "* Please Enter valid Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "* Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "* Please Enter valid Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords doesn't match!")]
        [Required(ErrorMessage = "* Enter Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "* Please Enter valid Email Address")]
        [Required(ErrorMessage = "* Email is required")]
        public string EmailAddress { get; set; }

        [Required]
        public int Role_ID { get; set; }

        //-- we provide different diff interface for each role ie for student role their is a dif ui for cell member there is diffrent ui for admin diff u
        //-- ans 1 >while restering user  we can take information about role 
        //-- ans 2 >or we can provide diiferent registration link/ui ie for student we maintain hinddent field with value =role id and where role ='student'
        //-- and for commitee member > only admin can add comitee members and and for that we have diff ui so we maintain hidden field where value = role id and roleid="comitte member"
        //-- and after succesful registration we send email(login credentioal + decription u r selected to grievance comitee cell) to comitte member 
        //---and for admin we already set login and creadentioal and then admin can edit their details;
        //--while login > there is a interface (one) for all so it will automatically check role fro database and provide appropriate ui to the user

    }
}
