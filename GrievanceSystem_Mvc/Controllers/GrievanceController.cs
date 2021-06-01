using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ServiceLayer;
using GrievanceSystem_Mvc.ViewModels;
using System.IO;
using GrievanceSystem_Mvc.Models;

namespace GrievanceSystem_Mvc.Controllers
{
    [Authorize]
    public class GrievanceController : Controller
    {

        readonly IGrievanceService gs;
        readonly ICategoryService cs;
        readonly ISubcategoryService ss;
        readonly IReplyService rs;

        public GrievanceController(IGrievanceService gs, ICategoryService cs, ISubcategoryService ss, IReplyService rs)
        {
            this.gs = gs;
            this.cs = cs;
            this.ss = ss;
            this.rs = rs;
        }

        //based on user id we need to provide  grieviences and for admin/commitee member we need to provide complete list 
        //we dont need to get userid from view we cant get it from session variable also TODO:
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {

            int userId = Convert.ToInt32(Session["CurrentUserID"]);
            List<GrievanceViewModel> grievanceViewModels = gs.GetGrievanceByUserId(userId);
            if (grievanceViewModels == null)
            {
                ViewData["Error"] = "Record Not Found Please try again";
                return View("Error");
            }

            return View(grievanceViewModels);

        }

        [HttpGet]
        [Authorize(Roles = "Admin ,Pricipal,Committee Member")]
        public ActionResult AllGrievances()
        {
            //TODO: Work on views buttons and all
            return View();

        }


        [Authorize(Roles = "Admin ,Pricipal,Committee Member")]
        public ActionResult GetAllGrievances()
        {
            //TODO: Work on views buttons and all

            List<GrievanceViewModel> grievances = gs.GetGrievance();

            return Json(new { data = grievances }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [Authorize(Roles = "Admin ,Pricipal,Committee Member")]
        public ActionResult PendingGrievances()
        {
            //TODO: Work on views buttons and all
            return View();

        }


        [Authorize(Roles = "Admin ,Pricipal,Committee Member")]
        public ActionResult GetPendingGrievances()
        {
            //TODO: Work on views buttons and all

            List<GrievanceViewModel> grievances = gs.GetPendingGrievances();

            return Json(new { data = grievances }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [Authorize(Roles = "Admin ,Pricipal,Committee Member")]
        public ActionResult ResolvedGrievances()
        {
            //TODO: Work on views buttons and all
            return View();

        }


        [Authorize(Roles = "Admin ,Pricipal,Committee Member")]
        public ActionResult GetResolvedGrievances()
        {
            //TODO: Work on views buttons and all

            List<GrievanceViewModel> grievances = gs.GetResolvedGrievances();

            return Json(new { data = grievances }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Details(int id)
        {
            GrievanceViewModel gvm = gs.GetGrievanceByGrievanceId(id);
            if (gvm.reply == null)
            {
                ReplyViewModel reply = new ReplyViewModel();
                gvm.reply = reply;

            }

            return View(gvm);


        }


        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Create()
        {

            List<CategoryViewModel> categories = cs.GetCategory().ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult Create(NewGrievanceViewModel newGrievance, HttpPostedFileBase file)
        {

            newGrievance.user_id = Convert.ToInt32(Session["CurrentUserID"]);
            newGrievance.status_id = 1;

            string uniqueFileName = null;

            if (file != null)
            {
                //set the path to receive file 
                string uploadPath = Server.MapPath(Helper.SetFilePath());


                string fileName = Path.GetFileName(file.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                
                string filePath = Path.Combine(uploadPath, uniqueFileName);

                file.SaveAs(filePath);
            }



            newGrievance.file = uniqueFileName;

            int rowAffected = gs.InsertGrievanceDetails(newGrievance);
            if (rowAffected == 0)
            {
                ViewData["Error"] = "Data is not inserted for some reason kindly try after some time ";
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        public ActionResult Edit(int id)
        {
            //TODO : on view we dont get exact category and subcategory we need to get category id and subcat id so or something else idk 

            List<CategoryViewModel> categories = GetCategories().ToList();
            ViewBag.categories = categories;

            List<SubcategoryViewModel> subcategories = GetSubCat().ToList();
            ViewBag.subcategories = subcategories;

            //here we need to get subcat aslo and we need to remove onchange event for dropbox for the instance :done
            GrievanceViewModel grievanceViewModel = gs.GetGrievanceByGrievanceId(id);
            if (grievanceViewModel == null)
            {
                ViewData["Error"] = "Record Not Found Please try again";
                return View("Error");
            }
            return View(grievanceViewModel);

        }


        [HttpPost]
        public ActionResult Edit(EditGrievanceViewModel GrievanceViewModel, FormCollection form)
        {

            GrievanceViewModel.Category_ID = Convert.ToInt32(Request.Form["category.CategoryID"]);
            GrievanceViewModel.Subcategory_ID = Convert.ToInt32(Request.Form["subcategory.SubcategoryID"]);
            int rowAffected = gs.UpdateGrievanceDetails(GrievanceViewModel);
            if (rowAffected == 0)
            {
                ViewData["Error"] = "Data is not Updated for some reason kindly try after some time ";
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //this is only for admin may be idk
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grievance/Delete/5
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



        public List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> categories = cs.GetCategory().ToList();
            return categories;


        }


        public List<SubcategoryViewModel> GetSubCat()
        {
            List<SubcategoryViewModel> subcategories = ss.GetSubcategory().ToList();
            return subcategories;

        }



        public ActionResult GetSubcategories(int categoryId)
        {

            List<SubcategoryViewModel> subcategories = ss.GetSubcategoryByCategoryId(categoryId).ToList();

            ViewBag.SubcatOptions = new SelectList(subcategories, "SubcategoryID", "SubcategoryName");

            var subcategoriesData = subcategories.Select(m => new SelectListItem()
            {
                Text = m.SubcategoryName.ToString(),
                Value = m.SubcategoryID.ToString(),
            });
            return Json(subcategoriesData, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetReplyByGrievanceId(int grievanceId)
        {
            ReplyViewModel reply = rs.GetReplyByGrievanceId(grievanceId);



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReply(FormCollection newReply)
        {

            NewReplyViewModel reply = new NewReplyViewModel()
            {

                ReplyMessage = Request.Form["reply.ReplyMessage"],
                User_ID = Convert.ToInt32(Session["CurrentUserID"]),
                Grievance_ID = Convert.ToInt32(Request.Form["GrievanceID"]),

            };
            int rowAffected = rs.InsertReply(reply);
            return RedirectToAction("Details", new { id = reply.Grievance_ID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReply(FormCollection newReply)
        {

            EditReplyViewModel reply = new EditReplyViewModel()
            {

                ReplyMessage = Request.Form["reply.ReplyMessage"],
                User_ID = Convert.ToInt32(Session["CurrentUserID"]),
                Grievance_ID = Convert.ToInt32(Request.Form["reply.Grievance_ID"]),
                ReplyID = Convert.ToInt32(Request.Form["reply.ReplyID"]),
            };
            int rowAffected = rs.UpdateReply(reply);
            return RedirectToAction("Details", new
            {
                id = reply.Grievance_ID
            });
        }

    }
}
