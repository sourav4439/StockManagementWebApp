using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace StockManagementWebApp.Models
{
    public class Company
    {
        
        public int Id { get; set; }
        [Required]
        public int RegistrationCode { get; set; }
        [Required]
        public string Name { get; set; }

        public Category Category { get; set; }
       
        public int CategoryId { get; set; }

    }
}