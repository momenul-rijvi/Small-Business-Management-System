using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.Controllers
{
    public class PurchasesController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        //
        // GET: /Purchases/
        public ActionResult Add()
        {
            var model = new Purchase();
            model.SupplierLookUp = GetSupplierSelectListItems();
            model.ProductLookUp = GetProductSelectListItems();

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Purchase purchase)
        {
            var model = new Purchase();
            model.SupplierLookUp = GetSupplierSelectListItems();
            model.ProductLookUp = GetProductSelectListItems();
            if (purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
            {
                bool isSave = _purchaseManager.Save(purchase);
                if (isSave)
                {
                    //var inPurchase = _db.Purchases.Where(c => c.Id == purchase.Id).FirstOrDefault();
                    //purchase.PurchaseDetailses = inPurchase.PurchaseDetailses;
                    return View(model);
                }
            }

            return View(model);
        }
        

        public List<SelectListItem> GetSupplierSelectListItems()
        {
            var dataList = _purchaseManager.GetSupplierList();

            var supplierSelectListItems = new List<SelectListItem>();

            supplierSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var supplier in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = supplier.Name;
                    selectListItem.Value = supplier.Id.ToString();

                    supplierSelectListItems.Add(selectListItem);
                }
            }
            return supplierSelectListItems;
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

        public List<SelectListItem> GetProductSelectListItems()
        {
            var dataList = _purchaseManager.GetProductList();

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
            var dataList = _purchaseManager.GetProductById(productId);
            var jsonData = dataList.Select(c => new { c.Id, c.Code });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }



	}
}