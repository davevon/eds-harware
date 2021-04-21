﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hardwarestore.Data;

namespace hardwarestore.Contracts
{
   

        public interface ICustomerRepository : IRepositoryBase<Customer>
        {
            ICollection<Customer> GetCustomerByID(int id);
        }

    
}
