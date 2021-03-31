using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Models
{
    public class ProductHistoryViewModel
    {
      [Required]
        public int Id { get; set; }
        // [ForeignKey("RequestingEmployeeViewId")]
        // public Employee RequestingEmployeeView { get; set; }
        public IEnumerable<SelectListItem> Employees;
        public string RequestingEmployeeViewId { get; set; }
        public DateTime DateViewed { get; set; }
        public bool? Approved { get; set; }

    }
}
