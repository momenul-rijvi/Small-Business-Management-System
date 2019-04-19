using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ReorderLevel { get; set; }
        public string Discription { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadFile { get; set; }
        [NotMapped]
        public List<SelectListItem> CategoryLookUp { get; set; }
         
    }
}