using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class SaleManager
    {
        SaleRepository _saleRepository = new SaleRepository();
        public List<Customer> GetCustomerList()
        {
            return _saleRepository.GetCustomerList();
        }

        public List<Customer> GetCustomerById(int customerId)
        {
            return _saleRepository.GetCustomerById(customerId);
        }

        public List<Product> GetProductList()
        {
            return _saleRepository.GetProductList();
        }

        public List<PurchaseDetails> GetProductById(int productId)
        {
            return _saleRepository.GetProductById(productId);
        }

        public bool Save(Sale sale)
        {
            return _saleRepository.Save(sale);
        }

        public List<SaleDetails> GetProductSaleById(int productId)
        {
            return _saleRepository.GetProductSaleById(productId);
        }

        public List<SaleDetails> ShowProductById(SaleDetails saleDetails)
        {
            return _saleRepository.ShowProductById(saleDetails);
        }
    }
}