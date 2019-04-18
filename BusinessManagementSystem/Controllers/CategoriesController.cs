using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        //
        // GET: /Catagorys/
        public ActionResult Add()
        {
            var datalist = _categoryManager.GetAll();
            if (datalist != null)
            {
                return View(datalist);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            try
            {
                if (category.Code != null && category.Name != null)
                {

                    bool isSave = _categoryManager.Save(category);
                    if (isSave)
                    {
                        ViewBag.isSuccess = "Saved";
                    }
                    else
                    {
                        ViewBag.fail = "Not Saved";
                    }
                    var datalist = _categoryManager.GetAll();
                    if (datalist != null)
                    {
                        return View(datalist);
                    }
                }
            }
            catch (Exception exception)
            {
                ViewBag.fail = exception.Message;
            }
            return View();
        }


        public ActionResult Delete(int Id)
        {
            bool isDelete = false;

            Category category = _categoryManager.GetCategoryById(Id);

            isDelete = _categoryManager.Delete(category);

            if (isDelete)
            {
                return RedirectToAction("Add");
            }
            return RedirectToAction("Delete");
        }

        public ActionResult Edit(int id)
        {
            var catagory = _categoryManager.GetCategoryById(id);
            return View(catagory);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var isUpdate = _categoryManager.Update(category);
                    if (isUpdate)
                    {
                        return RedirectToAction("Add");
                    }

                }
                return View(category);

            }
            catch (Exception e)
            {

                return View(category);
            }
        }
	}
}