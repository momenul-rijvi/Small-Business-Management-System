using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystem.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<SaleDetails> SaleDetailses { get; set; }

        [NotMapped]
        public List<SelectListItem> ProductLookUp { get; set; }
        [NotMapped]
        public List<SelectListItem> CustomerLookUp { get; set; }
        [NotMapped]
        public int ProductId { get; set; }
        [NotMapped]
        public virtual Product Product { get; set; }
        [NotMapped]
        public double GrandTotalValue { get; set; }

    }
}