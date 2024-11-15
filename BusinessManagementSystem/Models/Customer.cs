﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int LoyaltyPoint { get; set; }

        public byte[] File { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public HttpPostedFileBase Uploadfile { get; set; }
    }
}