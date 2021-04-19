using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerNAme { get; set; }
        public string CellNumber { get; set; }
        public DateTime Membership { get; set; }
    }
}
