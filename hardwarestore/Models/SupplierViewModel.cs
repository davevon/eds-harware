﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Models
{
    public class SupplierViewModel
    { 
        [Required]
        public int Id { get; set; }

       
        public IEnumerable<SelectListItem> suppliers { get; set; }
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string SupplierEmailAddress { get; set; }
        [Required]
        public string SupplierMailingAddress { get; set; }
        [Required]
        public string Telephone { get; set; }


    }
   /* public class CalcationViewModel
    {
        [Display(Name ="total number of Suppliers")]
        public int Totalsuppliers { get; set; }

        public int ReorderLevelTotal { get; set; }
        public ICollection<SupplierViewModel> suppliers { get; set; }
    }
*/


}
