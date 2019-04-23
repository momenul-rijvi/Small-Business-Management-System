using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class StockReportRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();

        public List<PurchaseDetails> Show(PurchaseDetails purchaseDetails)
        {
            return db.PurchaseDetailses.Where(c => c.ProductId == purchaseDetails.ProductId).ToList();
        }
    }
}