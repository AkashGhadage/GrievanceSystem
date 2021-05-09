using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //readonly private ISubcategoryService scs;
        //private readonly IReplyService rs;


        //public HomeController(ICategoryService cs)
        //{
        //    this.cs = cs;
        //}

        //public HomeController(ISubcategoryService scs)
        //{
        //    this.scs = scs;
        //}

        //public HomeController(IReplyService rs)
        //{
        //    this.rs = rs;
        //}

        // GET: Home

        //we need count of total grievances in index page 
        //for that here we crate ctor and create grievance object and get required values


        readonly IGrievanceService gs;

        public HomeController(IGrievanceService gs)
        {
            this.gs = gs;
        }

        public ActionResult Index()
        {
            //GrievanceStatViewModel grievanceStatViewModel = gs.GetGrievanceStat();
            //TODO: pass the model to view and retrive values
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
    }
}
