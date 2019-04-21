using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class PurchaseReportManager
    {
        PurchaseReportRepository _purchaseReportRepository = new PurchaseReportRepository();

        public List<Purchase> Show(Purchase purchase)
        {
            var dataList = _purchaseReportRepository.Show(purchase);
            return dataList;
        }
    }
}