using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.Models
{
    public class Item
    {
       
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public string ItemName { get; set; }
        public string ReorderLavel { get; set; }

    }
}