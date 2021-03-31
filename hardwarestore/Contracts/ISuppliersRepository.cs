using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hardwarestore.Data;

namespace hardwarestore.Contracts
{
    public interface ISuppliersRepository:IRepositoryBase<Supplier>
    {
        ICollection<Supplier> GetSuppliersByID(int id);
    }
}
