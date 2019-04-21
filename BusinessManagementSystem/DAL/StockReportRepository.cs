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
            var datalist = db.PurchaseDetailses.ToList();
            return datalist;
        }

        public List<Product> GetProductList()
        {
            return db.Products.ToList();
        }

        public List<Product> GetProductById(int productId)
        {
            return db.Products.Where(c => c.Id == productId).ToList();
        }
    }
}