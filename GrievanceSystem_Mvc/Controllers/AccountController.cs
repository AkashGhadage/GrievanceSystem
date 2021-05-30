using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;
using System.Web.Security;

namespace GrievanceSystem_Mvc.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserService us;


        public AccountController(IUserService us)
        {
            this.us = us;
        }

        // GET: Account

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, FormCollection formCollection)
        {

            if (ModelState.IsValid)
            {
                UserViewModel user = us.GetUserByEmailAndPassword(login.EmailAddress, login.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(login.EmailAddress, false);
                    Session["CurrentUserID"] = user.UserId; //here we need to get last generated record no and for that we need to modify out sp
                    Session["CurrentUserName"] = user.FirstName + " " + user.LastName;
                    Session["CurrentUserRole"] = user.Role;


                    if (User.IsInRole("Student"))
                    {
                        return RedirectToAction("Index", "Grievance");

                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Please enter valid data");
                    return View();

                }

            }
            else
            {
                ModelState.AddModelError("", "Please enter valid data");
                return View();
            }

        }

        // GET: Account/Create
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View("");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel user, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                int uid = us.InsertUser(user);


                Session["CurrentUserID"] = uid; //here we need to get last generated record no and for that we need to modify out sp
                Session["CurrentUserName"] = user.FirstName + " " + user.LastName;
                Session["CurrentUserEmail"] = user.EmailAddress;
                Session["CurrentUserPassword"] = user.Password;
                Session["CurrentUserIsAdmin"] = user.Password; // idk why this field is required 

                return RedirectToAction("Login", "Account"); //return to the login view after regiser

            }
            else
            {
                ModelState.AddModelError("id", "Invalid data");
                return View();  /*return To the same view*/

            }


        }

        public ActionResult Logout()
        {
            // TODO: Logout logic goes here
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        // GET: Account/Edit/5
        public ActionResult Edit()
        {


            int userId = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel uvm = us.GetUserByUserID(userId);

            EditUserViewModel editUserViewModel = new EditUserViewModel()
            {
                UserId = uvm.UserId,
                FirstName = uvm.FirstName,
                MiddleName = uvm.MiddleName,
                LastName = uvm.LastName,
                EmailAddress = uvm.EmailAddress,
                MobileNumber = uvm.MobileNumber
            };

            return View(editUserViewModel);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel editUserViewModel)
        {
            // TODO:update logic here
            if (ModelState.IsValid)
            {
                //here we need to cache username 

                editUserViewModel.UserId = Convert.ToInt32(Session["CurrentUserID"]);
                int rowAffected = us.UpdateUserDetails(editUserViewModel);
                Session["CurrentUserName"] = editUserViewModel.FirstName + " " + editUserViewModel.LastName;
                //Session["CurrentUserEmail"] = editUserViewModel.EmailAddress; no use may be  idk
                return View();

            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter valid data");
                return View(editUserViewModel);

            }

        }


        [HttpGet]
        public ActionResult ChangePassword()
        {

            int UserId = Convert.ToInt32(Session["CurrentUserID"]);
            //here we cannot get email value and password also i think we dont need password but we just need email adress and bcz of mappig problem we cant get email properly
            UserViewModel uvm = us.GetUserByUserID(UserId);

            EditUserPasswordViewModel editUserPasswordViewModel = new EditUserPasswordViewModel()
            {
                UserId = uvm.UserId,
                EmailAddress = uvm.EmailAddress,
                Password = "",
                ConfirmPassword = ""

            };
            return View(editUserPasswordViewModel);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(EditUserPasswordViewModel editUserPasswordViewModel)
        {
            //TODO: update logic here
            if (ModelState.IsValid)
            {

                //editUserViewModel.UserId = Convert.ToInt32(Session["CurrentUserID"]);

                //based on user id we change the password so uid is dominant
                int rowAffected = us.UpdateUserPassword(editUserPasswordViewModel);

                //Session["CurrentUserEmail"] = editUserPasswordViewModel.EmailAddress;
                return View();

            }
            else
            {
                return View(editUserPasswordViewModel);

            }

        }


        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
