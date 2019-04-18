using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        public ActionResult Save()
        {
            var datalist = _customerManager.GetAll();
            if (datalist != null)
            {
                return View(datalist);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            try
            {
                if (customer.Uploadfile != null)
                {
                    var fileByte = new byte[customer.Uploadfile.ContentLength];
                    customer.Uploadfile.InputStream.Read(fileByte, 0, customer.Uploadfile.ContentLength);
                    customer.File = fileByte;
                    customer.FileName = customer.Uploadfile.FileName;

                    bool isSave = _customerManager.Save(customer);
                    if (isSave)
                    {
                        ViewBag.isSuccess = "Saved";
                    }
                    else
                    {
                        ViewBag.fail = "Not Saved";
                    }
                    var datalist = _customerManager.GetAll();
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
            var customer = _customerManager.GetCustomerById(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            try
            {
                var fileByte = new byte[customer.Uploadfile.ContentLength];
                customer.Uploadfile.InputStream.Read(fileByte, 0, customer.Uploadfile.ContentLength);
                customer.File = fileByte;
                customer.FileName = customer.Uploadfile.FileName;
                bool isUpdate = _customerManager.Update(customer);
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

            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            Customer customer = _customerManager.GetCustomerById(id);
            if (customer != null)
            {
                bool isDelete = _customerManager.Delete(customer);
                if (isDelete)
                {
                    return RedirectToAction("Save");
                }

            }

            return RedirectToAction("Save");

        }
	}
}