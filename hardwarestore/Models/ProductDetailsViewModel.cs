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
        public string ProductName { get; set; }

        public IEnumerable<SelectListItem> Suppliers;
        public SupplierViewModel Supplier { get; set; }
        public int SupplierId { get; set; }

        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }

        [Required]
        [Range(350,1000)]
        public int ReOrderLevel { get; set; }

    }

    public class CreateLeaveTypeViewModel
    {
        public List< SupplierViewModel> Suppliers { set; get; }

    }
}
