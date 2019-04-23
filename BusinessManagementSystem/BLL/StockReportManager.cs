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
        StockReportRepository _stockReportRepository= new StockReportRepository();
        public List<PurchaseDetails> Show(PurchaseDetails purchaseDetails)
        {
            return _stockReportRepository.Show(purchaseDetails);
        }
    }
}