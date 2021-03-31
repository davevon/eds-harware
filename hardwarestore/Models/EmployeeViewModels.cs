using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Models
{
    public class EmployeeViewModels
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        ///add fields
        public string Firstname { get; set; }
        public string Lasttname { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

    }
}
