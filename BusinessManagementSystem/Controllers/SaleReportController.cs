using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class SaleReportController : Controller
    {
        SaleManager _saleManager = new SaleManager();
        //
        // GET: /SaleReport/
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SaleDetails saleDetails)
        {
            var datalist = _saleManager.ShowProductById(saleDetails);
            return View(datalist);

        }
	}
}