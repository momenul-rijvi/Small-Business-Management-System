using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class StockReportController : Controller
    {
        StockReportManager _stockReportManager = new StockReportManager();
        //
        // GET: /StockReport/
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(PurchaseDetails purchaseDetails)
        {
            var dataList = _stockReportManager.Show(purchaseDetails);
            return View(dataList);
        }
	}
}