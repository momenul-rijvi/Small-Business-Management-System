using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class StockReportManager
    {
        StockReportRepository _stockReportRepository = new StockReportRepository();

        public List<PurchaseDetails> Show(PurchaseDetails purchaseDetails)
        {
            var dataList = _stockReportRepository.Show(purchaseDetails);
            return dataList;
        }

        public List<Product> GetProductList()
        {
            return _stockReportRepository.GetProductList();
        }

        public List<Product> GetProductById(int productId)
        {
            return _stockReportRepository.GetProductById(productId);
        }


    }
}