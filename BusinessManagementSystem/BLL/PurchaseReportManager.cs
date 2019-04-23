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
        PurchaseReportRepository _purchaseReportRepository= new PurchaseReportRepository();
        public List<int> Show(DateTime s, DateTime e)
        {
            return _purchaseReportRepository.Show(s, e);
        }

        public List<PurchaseDetails> GetPurchaseDetails(List<int> dataList)
        {
            return _purchaseReportRepository.GetPurchaseDetails(dataList);
        }

        public List<PurchaseDetails> ShowAll(PurchaseDetails purchaseDetails)
        {
            return _purchaseReportRepository.ShowAll(purchaseDetails);
        }
    }
}