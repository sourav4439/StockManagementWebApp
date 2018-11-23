using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name =" Available Quantity")]
        public int TotalQuantity { get; set; }
      


    }
}