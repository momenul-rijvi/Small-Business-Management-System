using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class SuppliersController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();

        public ActionResult Save()
        {
            var datalist = _supplierManager.GetAll();
            if (datalist != null)
            {
                return View(datalist);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Save(Supplier supplier)
        {
            try
            {
                if (supplier.Uploadfiles != null)
                {
                    var fileByte = new byte[supplier.Uploadfiles.ContentLength];
                    supplier.Uploadfiles.InputStream.Read(fileByte, 0, supplier.Uploadfiles.ContentLength);
                    supplier.File = fileByte;
                    supplier.FileName = supplier.Uploadfiles.FileName;

                    bool isSave = _supplierManager.Save(supplier);
                    if (isSave)
                    {
                        ViewBag.isSuccess = "Saved";
                    }
                    else
                    {
                        ViewBag.fail = "Not Saved";
                    }
                    var datalist = _supplierManager.GetAll();
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
            var supplier = _supplierManager.GetsupplierById(id);
            return View(supplier);
        }
        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {
            try
            {
                var fileByte = new byte[supplier.Uploadfiles.ContentLength];
                supplier.Uploadfiles.InputStream.Read(fileByte, 0, supplier.Uploadfiles.ContentLength);
                supplier.File = fileByte;
                supplier.FileName = supplier.Uploadfiles.FileName;
                bool isUpdate = _supplierManager.Update(supplier);
                if (isUpdate)
                {
                    return RedirectToAction("Save");
                }
                ViewBag.fail = "Sorry! Successfully Failed";
            }
            catch (Exception e)
            {
                ViewBag.fail = e.Message;
            }

            return View(supplier);
        }

        public ActionResult Delete(int id)
        {
            Supplier supplier = _supplierManager.GetsupplierById(id);
            if (supplier != null)
            {
                bool isDelete = _supplierManager.Delete(supplier);
                if (isDelete)
                {
                    return RedirectToAction("Save");
                }

            }

            return RedirectToAction("Save");

        }
	}
}