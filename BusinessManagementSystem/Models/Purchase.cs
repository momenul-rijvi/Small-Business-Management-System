﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystem.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BillNo { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual List<PurchaseDetails> PurchaseDetailses { get; set; }



        [NotMapped]
        public List<SelectListItem> ProductLookUp { get; set; }
        [NotMapped]
        public List<SelectListItem> SupplierLookUp { get; set; }
        [NotMapped]
        public int ProductId { get; set; }
        [NotMapped]
        public virtual Product Product { get; set; }

        [NotMapped]
        public DateTime StarDate { get; set; }
        [NotMapped]
        public DateTime EndDate { get; set; }

    }
}