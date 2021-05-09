using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrievanceSystem_Mvc.ViewModels
{
    public class EditUserPasswordViewModel
    {

        public int UserId { get; set; }

        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "* Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "* Please Enter valid Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords doesn't match!")]
        [Required(ErrorMessage = "* Enter Password")]
        public string ConfirmPassword { get; set; }


    }
}
