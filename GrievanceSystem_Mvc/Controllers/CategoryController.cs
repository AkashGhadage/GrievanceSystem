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
    public class CategoryController : Controller
    {

        readonly ICategoryService cs;
        public CategoryController(ICategoryService cs)
        {
            this.cs = cs;

        }
        // GET: Category
        public ActionResult Index()
        {

            return View();
        }

        // GET: Category/Details/5
        public ActionResult GetCategories()
        {

            List<CategoryViewModel> categories = cs.GetCategory();

            return Json(new { data = categories }, JsonRequestBehavior.AllowGet);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel newCategory, FormCollection collection)
        {
            int rowAffected = cs.InsertCategory(newCategory);
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryViewModel category = cs.GetCategoryById(id);

            EditCategoryViewModel editCategory = new EditCategoryViewModel()
            {
                CategoryName = category.CategoryName,
                CategoryID = category.CategoryID
            };
            return View(editCategory);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel editCategory, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                int rowAffected = cs.UpdateCategory(editCategory);
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
                return View(editCategory);

            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryViewModel category = cs.GetCategoryById(id);

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int rowAffected = cs.DeleteCategory(id);
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
