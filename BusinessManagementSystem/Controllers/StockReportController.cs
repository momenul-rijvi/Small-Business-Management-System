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
            var purchaseDetails = new PurchaseDetails();

           // var model = new Purchase();
           
           // model.ProductLookUp = GetProductSelectListItems();

            var dataList = _stockReportManager.Show(purchaseDetails);
            return View(dataList);
        }
        [HttpPost]
        public ActionResult Search(PurchaseDetails purchaseDetails)
        {
            var dataList = _stockReportManager.Show(purchaseDetails);
            return View(dataList);

        }

        /*[HttpPost]
        public ActionResult Search(PurchaseDetails purchaseDetails)
        {
            var dataList = _stockReportManager.Show(purchaseDetails);
            return View(dataList);

        }*/


        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var dataList = new List<SelectListItem>();
            var defaultSelectListItem = new SelectListItem();
            defaultSelectListItem.Text = "---Select---";
            defaultSelectListItem.Value = "";
            dataList.Add(defaultSelectListItem);
            return dataList;
        }
        public List<SelectListItem> GetProductSelectListItems()
        {
            var dataList = _stockReportManager.GetProductList();

            var productSelectListItems = new List<SelectListItem>();

            productSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var product in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = product.Name;
                    selectListItem.Value = product.Id.ToString();

                    productSelectListItems.Add(selectListItem);
                }
            }
            return productSelectListItems;
        }
        public JsonResult GetByProductId(int productId)
        {
            var dataList = _stockReportManager.GetProductById(productId);
            var jsonData = dataList.Select(c => new { c.Id, c.Code });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
     
	}
}