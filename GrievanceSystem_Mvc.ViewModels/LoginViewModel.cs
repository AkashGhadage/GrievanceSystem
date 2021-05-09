﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GrievanceSystem_Mvc.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "* Please Enter valid Email Address")]
        [Required(ErrorMessage = "* Email is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "* Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "* Please Enter valid Password")]
        public string Password { get; set; }

    }
}
