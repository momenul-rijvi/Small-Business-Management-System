using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;

namespace BusinessManagementSystem.Controllers
{
    public class SalesReportController : Controller
    {
        SalesReportManager _salesReportManager = new SalesReportManager();

        //
        // GET: /SalesReportRepository/
        public ActionResult Search()
        {
            return View();
        }
	}
}