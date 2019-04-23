using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class SaleRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();
        public List<Customer> GetCustomerList()
        {
            return db.Customers.ToList();
        }

        public List<Customer> GetCustomerById(int customerId)
        {
            return db.Customers.Where(c => c.Id == customerId).ToList();
        }

        public List<Product> GetProductList()
        {
            return db.Products.ToList();
        }

        public List<PurchaseDetails> GetProductById(int productId)
        {
            return db.PurchaseDetailses.Where(c => c.ProductId == productId).ToList();
        }

        public bool Save(Sale sale)
        {
            db.Sales.Add(sale);
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

        public List<SaleDetails> GetProductSaleById(int productId)
        {
            return db.SaleDetailses.Where(p => p.ProductId == productId).ToList();
        }

        public List<SaleDetails> ShowProductById(SaleDetails saleDetails)
        {
            return db.SaleDetailses.Where(c => c.ProductId == saleDetails.ProductId).ToList();
        }
    }
}