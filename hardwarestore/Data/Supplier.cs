using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class Supplier
    {[Key]
        public int Id { get; set; }
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string SupplierEmailAddress { get; set; }
        [Required]
        public string SupplierMailingAddress { get; set; }
        [Required]
        public string Telephone { get; set; }
 
    }
}
