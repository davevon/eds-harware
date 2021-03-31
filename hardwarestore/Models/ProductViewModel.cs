using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Models
{
    public class ProductViewModel
    {
      
        public int Id { get; set; }
        [Required]
        public IEnumerable<SelectListItem> products { get; set; }
        public string Name { get; set; }

    }
}
