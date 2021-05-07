using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class SalesItem
    {
        [Key]
        public int SalesItemId { get; set; }

        [ForeignKey("CustomerId")]
   
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public string CustomerNAme{ get; set; }
        
        [ForeignKey("ProductId")]
        public ProductDetail ProdDetails { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }

        public double Total { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
