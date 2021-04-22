using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class Customer
    { [Key]
        public int CustomerId { get; set; }
        public string CustomerNAme { get; set; }
        public string CellNumber { get; set; }
        public DateTime Membership { get; set; }
    }
}
