using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{

    public class PurchaseRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();

        public List<Supplier> GetSupplierList()
        {
            return db.Suppliers.ToList();
        }

        public List<Product> GetProductList()
        {
            return db.Products.ToList();
        }

        public List<Product> GetProductById(int productId)
        {
            return db.Products.Where(c => c.Id == productId).ToList();
        }

        public bool Save(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            int rowAfected = db.SaveChanges();
            if (rowAfected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}