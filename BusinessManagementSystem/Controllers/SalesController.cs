using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        SaleManager _saleManager= new SaleManager();
        CustomerManager _customerManager = new CustomerManager();
        //
        // GET: /Sales/
        public ActionResult Sale()
        {
            var model = new Sale();
            model.CustomerLookUp = GetCustomerSelectListItems();
            model.ProductLookUp = GetProductSelectListItems();

            return View(model);
        }

        [HttpPost]
        public ActionResult Sale(Sale sale, double? GrandTotalValue, int CustomerId)
        {

            var model = new Sale();
            model.CustomerLookUp = GetCustomerSelectListItems();
            model.ProductLookUp = GetProductSelectListItems();
            if (sale.SaleDetailses != null && sale.SaleDetailses.Count > 0)
            {
                bool isSave = _saleManager.Save(sale);
                if (isSave)
                {
                    //var inPurchase = _db.Purchases.Where(c => c.Id == purchase.Id).FirstOrDefault();
                    //purchase.PurchaseDetailses = inPurchase.PurchaseDetailses;
                    var cust = _customerManager.GetCustomerById(CustomerId);
                    cust.LoyaltyPoint = (int)(cust.LoyaltyPoint + GrandTotalValue / 1000);
                    _customerManager.Update(cust);

                    return View(model);
                }
                
                //
                


            }

            return View(model);
        }
        

        public List<SelectListItem> GetCustomerSelectListItems()
        {
            var dataList = _saleManager.GetCustomerList();

            var customerSelectListItems = new List<SelectListItem>();

            customerSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var customer in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = customer.Name;
                    selectListItem.Value = customer.Id.ToString();

                    customerSelectListItems.Add(selectListItem);
                }
            }
            return customerSelectListItems;
        }

        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var dataList = new List<SelectListItem>();
            var defaultSelectListItem = new SelectListItem();
            defaultSelectListItem.Text = "---Select---";
            defaultSelectListItem.Value = "";
            dataList.Add(defaultSelectListItem);
            return dataList;
        }
        public JsonResult GetByCustomerId(int customerId)
        {
            var dataList = _saleManager.GetCustomerById(customerId);
            var jsonData = dataList.Select(c => new { c.Id, c.LoyaltyPoint });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public List<SelectListItem> GetProductSelectListItems()
        {
            var dataList = _saleManager.GetProductList();

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

        //purchase
        public JsonResult GetProductById(int productId)
        {
            var dataList = _saleManager.GetProductById(productId);
            var jsonData = dataList.Select(c => new { c.Quantity, c.UnitPrice});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductSaleById(int productId)
        {
            var dataList = _saleManager.GetProductSaleById(productId);


            var jsonData = dataList.Select(c => new { c.Quantity });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
	}
}