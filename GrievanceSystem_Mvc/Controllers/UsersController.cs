using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.Controllers
{
    [Authorize(Roles = "Admin ,Pricipal")]
    public class UsersController : Controller
    {

        readonly IUserService us;


        public UsersController(IUserService us)
        {
            this.us = us;
        }

        // GET: Users
        [HttpGet]
        public ActionResult CellMember()
        {
            return View();
        }

        // GET: Users/GetCellMember/5
        [HttpGet]
        public ActionResult GetCellMember()
        {
            List<UserViewModel> cellMembers = us.GetUsersByRoleId(3).ToList();
            return Json(new { data = cellMembers }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult CreateCellMember()
        {

            return View(new RegisterViewModel());

        }

        [HttpPost]

        public ActionResult CreateCellMember(RegisterViewModel user, FormCollection formCollection)
        {
            int uid = us.InsertUser(user);
            //changes
            if (uid == 0)
            {
                return new JsonResult { Data = new { result = false, message = "data was not saved successfully!" } };

            }
            else
            {
                return new JsonResult { Data = new { result = true, message = "data saved successfully!" } };

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            UserViewModel user = us.GetUserByUserID(id);

            EditUserViewModel editUser = new EditUserViewModel()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                MobileNumber = user.MobileNumber
            };

            return View(editUser);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel editUserViewModel)
        {
            // TODO:update logic here
            //check repository layer for email field 
            if (ModelState.IsValid)
            {
                int rowAffected = us.UpdateUserDetails(editUserViewModel);
                if (rowAffected == 0)
                {
                    return new JsonResult { Data = new { result = false, message = "data was not Updated successfully!" } };
                }
                else
                {
                    return new JsonResult { Data = new { result = true, message = "data Updated successfully!" } };
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter valid data");
                return View(editUserViewModel);

            }

        }


        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);

            //here we cannot get email value and password also i think we dont need password but we just need email adress and bcz of mappig problem we cant get email properly
            UserViewModel user = us.GetUserByUserID(id);


            EditUserPasswordViewModel editUserPasswordViewModel = new EditUserPasswordViewModel()
            {
                UserId = user.UserId,
                EmailAddress = user.EmailAddress,
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
                //based on user id we change the password so uid is dominant
                int rowAffected = us.UpdateUserPassword(editUserPasswordViewModel);
                if (rowAffected == 0)
                {
                    return new JsonResult { Data = new { result = false, message = "Password was not Updated successfully!" } };
                }
                else
                {
                    return new JsonResult { Data = new { result = true, message = "Password Updated successfully!" } };
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter valid data");
                return View(editUserPasswordViewModel);

            }

        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            UserViewModel user = us.GetUserByUserID(id);

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int rowAffected = us.DeleteUser(id);
            if (rowAffected == 0)
            {
                return new JsonResult { Data = new { result = false, message = "data was not Deleted successfully!" } };
            }
            else
            {
                return new JsonResult { Data = new { result = true, message = "data Deleted successfully!" } };
            }
        }

        // GET: Users
        [HttpGet]
        public ActionResult Students()
        {
            return View();
        }


        public ActionResult GetStudents()
        {
            //int userId = Convert.ToInt32(Session["CurrentUserID"]);
            int userId = 2;
            List<UserViewModel> student = us.GetUsersByRoleId(userId).ToList();

            return Json(new { data = student }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult CreateStudent()
        {

            return View(new RegisterViewModel());

        }

        [HttpPost]
        public ActionResult CreateStudent(RegisterViewModel user, FormCollection formCollection)
        {
            int uid = us.InsertUser(user);
            if (uid == 0)
            {
                return new JsonResult { Data = new { result = false, message = "data was not saved successfully!" } };

            }
            else
            {
                return new JsonResult { Data = new { result = true, message = "data saved successfully!" } };

            }
        }
    }
}