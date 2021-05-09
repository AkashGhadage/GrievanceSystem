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
    public class SubcategoryController : Controller
    {
        readonly ISubcategoryService sc;
        readonly ICategoryService cs;
        public SubcategoryController(ISubcategoryService sc, ICategoryService cs)
        {
            this.sc = sc;
            this.cs = cs;

        }
        // GET: Subategory
        public ActionResult Index()
        {
            CategoryViewModel c = new CategoryViewModel()
            {
                CategoryID = 0,
                CategoryName = "All"
            };
            List<CategoryViewModel> categories = cs.GetCategory().ToList();
            categories.Insert(0, c);
            ViewBag.categories = categories;
            return View();
        }

        // GET: Subategory/GetSubcategories/5
        public ActionResult GetSubcategories()
        {
            List<SubcategoryViewModel> Subcategories = sc.GetSubcategory();
            return Json(new { data = Subcategories }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubcategoriesByCategoryId(int id)
        {
            List<SubcategoryViewModel> Subcategories;
            if (id == 0)
            {
                Subcategories = sc.GetSubcategory();

            }
            else
            {
                Subcategories = sc.GetSubcategoryByCategoryId(id);

            }
            return Json(new { data = Subcategories }, JsonRequestBehavior.AllowGet);

        }



        // GET: Subcategory/Create
        public ActionResult Create()
        {
            //form here we need to pass list of category

            List<CategoryViewModel> categories = cs.GetCategory().ToList();
            ViewBag.categories = categories;
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(NewSubcategoryViewModel subcategory, FormCollection collection)
        {
            int rowAffected = sc.InsertSubcategory(subcategory);
            //changes
            if (rowAffected == 0)
            {
                return new JsonResult { Data = new { result = false, message = "data was not saved successfully!" } };

            }
            else
            {
                return new JsonResult { Data = new { result = true, message = "data saved successfully!" } };

            }
        }

        public ActionResult Edit(int id)
        {
            List<CategoryViewModel> categories = cs.GetCategory().ToList();
            ViewBag.categories = categories;

            SubcategoryViewModel subcategory = sc.GetSubategoryById(id);
            EditSubcategoryViewModel editsubcategory = new EditSubcategoryViewModel()
            {
                SubcategoryID = subcategory.SubcategoryID,
                SubcategoryName = subcategory.SubcategoryName,
                Category_ID = subcategory.Category_ID
            };
            return View(editsubcategory);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(EditSubcategoryViewModel editSubcategory, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                int rowAffected = sc.UpdateSubcategory(editSubcategory);
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
                return View(editSubcategory);

            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            SubcategoryViewModel subcategory = sc.GetSubategoryById(id);
            return View(subcategory);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int rowAffected = sc.DeleteSubcategory(id);
            if (rowAffected == 0)
            {
                return new JsonResult { Data = new { result = false, message = "data was not Deleted successfully!" } };
            }
            else
            {
                return new JsonResult { Data = new { result = true, message = "data Deleted successfully!" } };
            }
        }
    }
}