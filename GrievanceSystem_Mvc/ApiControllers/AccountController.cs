using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.Api_Controllers
{
    public class AccountController : ApiController
    {
        IUserService us;

        public AccountController(IUserService us)
        {
                    this.us = us;
        }


        public string GetEmail(string email)
        {

            if (us.GetUserByEmail(email) != null)
            {
                ModelState.AddModelError("EmailAddress", "* Email Already Registered");
                return "Found";

            }
            else
            {
                return "Not found";
            }

            //on the view you nedd to call this api controller and need to pass the value of email adress  ie use ajax
        }
    }
}
