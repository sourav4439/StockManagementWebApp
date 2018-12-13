using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.Models
{
    public class StockOut
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        [Display(Name = " Stock Out Quantity")]
        public int TotalQuantity { get; set; }

        public DateTime Date { get; set; }

        public Track Track { get; set; }
        public byte TrackId { get; set; }

    }

    public class Track
    {
        public byte Id { get; set; }
        public string Trackname { get; set; }
    }
}