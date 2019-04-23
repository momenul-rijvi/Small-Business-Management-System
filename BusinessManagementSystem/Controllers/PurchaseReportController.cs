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
            return View();
        }
        [HttpPost]
        public ActionResult Search(PurchaseDetails purchaseDetails)
        {
            // var purchase = new PurchaseDetails();
            
            /*DateTime s = purchaseDetails.StarDate;
            DateTime e = purchaseDetails.EndDate;
            var dataList = _purchaseReportManager.Show(s, e);
            var datar = _purchaseReportManager.GetPurchaseDetails(dataList);*/
            var datalist = _purchaseReportManager.ShowAll(purchaseDetails);
            return View(datalist);

        }
	}
}