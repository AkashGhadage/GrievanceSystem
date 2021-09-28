using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ViewModels;
using GrievanceSystem_Mvc.ServiceLayer;


namespace GrievanceSystem_Mvc.Controllers
{
    public class ReportController : Controller
    {
        readonly IReportService rs;
      

        public ReportController(IReportService rs)
        {
            this.rs = rs;
        }



        public ActionResult Index()
        {

            return View();


        }
        // GET: Report
        public ActionResult GetDetailedReport(DateTime? startDate, DateTime? endDate)
        {

            //here get data  that you want to show on UI 
            //call this action method using ajax call and from there pass the dates

           List<GrievanceViewModel>  grievances = rs.GetDetailedReport(startDate,endDate);

            return Json(new { data = grievances }, JsonRequestBehavior.AllowGet);


        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
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
