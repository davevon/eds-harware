using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Models
{
    public class ProductDetailsViewModel
    {
        [Key]
        public int Id { get; set; }
    
        ///public Product Product { get; set; }
        public int ProductId { get; set; }
      
        //public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public IEnumerable<SelectListItem> productdetails;
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Queantity { get; set; }

    }
}
