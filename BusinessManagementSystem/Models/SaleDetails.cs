using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessManagementSystem.Models
{
    public class SaleDetails
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        
    }
}