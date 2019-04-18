using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        ProductManager _productManager= new ProductManager();
        //
        // GET: /Products/
        public ActionResult Add()
        {
            var datalist = _productManager.GetAll();
            if (datalist != null)
            {
                return View(datalist);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            try
            {
                if (product.Name != null && product.Code != null && product.ReorderLevel != null)
                {
                    var fileByte = new byte[product.UploadFile.ContentLength];
                    product.UploadFile.InputStream.Read(fileByte, 0, product.UploadFile.ContentLength);
                    product.File = fileByte;
                    product.FileName = product.UploadFile.FileName;
                    bool isSave = _productManager.Save(product);
                    if (isSave)
                    {
                        ViewBag.isSuccess = "Saved";
                    }
                    else
                    {
                        ViewBag.fail = "Not Saved";
                    }
                    var datalist = _productManager.GetAll();
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
        public ActionResult Update(int id)
        {

            var product = _productManager.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            try
            {
                var fileByte = new byte[product.UploadFile.ContentLength];
                product.UploadFile.InputStream.Read(fileByte, 0, product.UploadFile.ContentLength);
                product.File = fileByte;
                product.FileName = product.UploadFile.FileName;
                bool isUpdate = _productManager.Update(product);
                if (isUpdate)
                {
                    return RedirectToAction("Add");
                }
                ViewBag.fail = "Sorry! Successfully Failed";
            }
            catch (Exception e)
            {
                ViewBag.fail = e.Message;
            }
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            Product product = _productManager.GetProductById(id);
            if (product != null)
            {
                bool isDelete = _productManager.Delete(product);
                if (isDelete)
                {
                    return RedirectToAction("Add");
                }

            }

            return RedirectToAction("Add");

        }

        public JsonResult GetAllCategory()
        {
            var dataList = _productManager.GetAllCategoy();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
	}
}