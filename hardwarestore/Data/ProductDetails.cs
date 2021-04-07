using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class ProductDetails
    {[Key]
        public int Id { get; set; }
      
        public string Name { get; set; }
     
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Queantity{ get; set; }

    }
}
