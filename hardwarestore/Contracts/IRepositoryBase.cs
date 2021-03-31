using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hardwarestore.Contracts
{
    public interface IRepositoryBase <T> where T:class
    {
        ICollection<T> FindAll();//returning all data from this class within the database

      
        T FindById(int id);//finding a record by id
        bool isExist(int id);
        bool Create(T entity);//yes or no
        bool Update(T entity);
        bool Delete(T entity);
        bool save();

    
    }
}
