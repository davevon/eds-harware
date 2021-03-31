using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hardwarestore.Contracts;
using hardwarestore.Data;

namespace hardwarestore.Reopository
{
    public class ProductHistoryRepository : IProductHistoryRepository
    {
        private readonly ApplicationDbContext _db;// the databease in initialise in the programm

        public ProductHistoryRepository(ApplicationDbContext db)// paassing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(ProductHistory entity)
        {
            _db.ProdHistories.Add(entity);
            return save();
           // throw new NotImplementedException();
        }

        public bool Delete(ProductHistory entity)
        {
            _db.ProdHistories.Remove(entity);
            return save();
           // throw new NotImplementedException();
        }

        public ICollection<ProductHistory> FindAll()
        {
            _db.ProdHistories.ToList();
            return _db.ProdHistories.ToList();
           // throw new NotImplementedException();
        }

        public ProductHistory FindById(int id)
        {
            _db.ProdHistories.Find(id);
            return _db.ProdHistories.Find(id);
           // throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.Suppliers.Any(q => q.Id == id);
            return exist;
        }

        public bool save()
        {
            _db.SaveChanges();
            return _db.SaveChanges() > 0;
           // throw new NotImplementedException();
        }

        public bool Update(ProductHistory entity)
        {
            _db.ProdHistories.Update(entity);
            return save();
           // throw new NotImplementedException();
        }
    }
}
