using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        [Required]
        public string CustomerNAme { get; set; }
        [Required]
        public string CellNumber { get; set; }
        [Required]
        public DateTime Membership { get; set; }








    }
}
