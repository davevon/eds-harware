﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Models
{
    public class SalesItemViewModel
    {
        [Key]
        public int SalesId { get; set; }

       // public CustomerViewModel Customers { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public string CustomerNAme { get; set; }

       // public IEnumerable<SelectListItem>  SalesListItems{ get; set; }
        public  IEnumerable<SelectListItem> ProductDetails { get; set; }
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Total { get; set; }

    }
}
