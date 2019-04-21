using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class PurchaseReportController : Controller
    {
        PurchaseReportManager _purchaseReportManager = new PurchaseReportManager();

        //
        // GET: /PurchaseReport/
        public ActionResult Search()
        {
            /*var purchase = new Purchase();
            var dataList = _purchaseReportManager.Show(purchase);
            return View(dataList);*/
            return View();

        }
     
        [HttpPost]
        public ActionResult Search(Purchase purchase)
        {
            // var purchase = new PurchaseDetails();
            var dataList = _purchaseReportManager.Show(purchase);
            return View(dataList);

        }
	}
}