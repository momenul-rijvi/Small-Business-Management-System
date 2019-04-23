using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessManagementSystem.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double MRP { get; set; }


        [NotMapped]
        public virtual List<SaleDetails> SaleDetails { get; set; }
        [NotMapped]
        public DateTime StarDate { get; set; }
        [NotMapped]
        public DateTime EndDate { get; set; }

    }
}