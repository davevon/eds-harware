using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class ProductDetail
    {[Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [ForeignKey("SupplierId")] 
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }

        public int ReOrderLevel {get;set;}


    }
}
