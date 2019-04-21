using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class PurchaseReportRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();
 
        public List<Purchase> Show(Purchase purchase)
        {
            /*var datalist = db.Purchases.ToList();*/
            var datalist = db.Purchases.Where(p => p.Date >= purchase.StarDate && p.Date <= purchase.EndDate).ToList();
            //var datalist = db.PurchaseDetailses.Where(x => x.CurrentDate >= purchaseDetails.StarDate && x.CurrentDate <= purchaseDetails.EndDate).ToList();


            // Customer nCustomer = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return datalist;
        }
    }
}