using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository= new PurchaseRepository();

        public List<Supplier> GetSupplierList()
        {
            return _purchaseRepository.GetSupplierList();
        }

        public List<Product> GetProductList()
        {
            return _purchaseRepository.GetProductList();
        }

        public List<Product> GetProductById(int productId)
        {
            return _purchaseRepository.GetProductById(productId);
        }

        public bool Save(Purchase purchase)
        {
            return _purchaseRepository.Save(purchase);
        }
    }
}