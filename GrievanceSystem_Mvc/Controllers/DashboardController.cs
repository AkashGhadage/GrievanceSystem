using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard

        public ActionResult Users()
        {
            UserViewModel userViewModel = new UserViewModel()
            {

                FirstName = "Akash",
                LastName = "ghadage",
                EmailAddress = "Akash@gmail.com"
            };

            List<UserViewModel> userViewModels = new List<UserViewModel>();
            userViewModels.Add(userViewModel);
            return View(userViewModels);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSubcategory(NewSubcategoryViewModel subcategoryViewModel)
        {
            return View();
        }

        public ActionResult AllGrievances()
        {
            //TODO: Work on views buttons and all

            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

    }
}