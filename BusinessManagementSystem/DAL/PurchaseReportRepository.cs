using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class PurchaseReportRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();

        public List<int> Show(DateTime s, DateTime e)
        {
            var datalist = db.Purchases.Where(p => p.Date >= s && p.Date <= e).Select(p=>p.Id).ToList();

            /*foreach (var d in datalist)
            {
                db.PurchaseDetailses.Where(p => p.PurchaseId == d).ToList();
            }*/
            return datalist;
        }

        public List<PurchaseDetails> GetPurchaseDetails(List<int> dataList)
        {
            /*List<PurchaseDetails> datar = null;
            foreach (var data in dataList)
            {
                datar=db.PurchaseDetailses.Where(p => p.ProductId == data).ToList();
                
            }return datar;*/
            return db.PurchaseDetailses.Where(p => p.ProductId== dataList.Count).ToList();
            
        }

        public List<PurchaseDetails> ShowAll(PurchaseDetails purchaseDetails)
        {
            return db.PurchaseDetailses.Where(c => c.ProductId == purchaseDetails.ProductId).ToList(); 
        }
    }
}