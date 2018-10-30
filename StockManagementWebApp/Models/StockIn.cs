using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.Models
{
    public class StockIn
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public int TotalQuantity { get; set; }
       
    }
}