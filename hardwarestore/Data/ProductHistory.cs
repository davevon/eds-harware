using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Data
{
    public class ProductHistory
    {[Key]
        public int Id { get; set; }
        [ForeignKey("RequestingEmployeeViewId")]
        public Employee RequestingEmployeeView { get; set; }
   public string RequestingEmployeeViewId { get; set; }
   public DateTime Datesold { get; set; }
   public bool? Approved { get; set; }
        public string productId { get; set; }
        
        public double totalPaid { get; set; }

    }
}
