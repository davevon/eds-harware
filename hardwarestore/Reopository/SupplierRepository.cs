using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hardwarestore.Contracts;
using hardwarestore.Data;

namespace hardwarestore.Reopository
{
    public class SupplierRepository : ISuppliersRepository
   
    {
        private readonly ApplicationDbContext _db;// the databease in initialise in the programm

        public SupplierRepository(ApplicationDbContext db)// paassing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(Supplier entity)
        {
            _db.Suppliers.Add(entity);
            // throw new NotImplementedException();
            return save();
        }

        public bool Delete(Supplier entity)
        {
            _db.Suppliers.Remove(entity);
            return save();
            //throw new NotImplementedException();
        }

        public ICollection<Supplier> FindAll()
        {
            _db.Suppliers.ToList();
            return _db.Suppliers.ToList();
            //throw new NotImplementedException();
        }

        public Supplier FindById(int id)
        {
            _db.Suppliers.Find(id);
            return _db.Suppliers.Find(id);
           // throw new NotImplementedException();
        }

        public ICollection<Supplier> GetSuppliersByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.Suppliers.Any(q => q.Id == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
           // throw new NotImplementedException();
        }

        public bool Update(Supplier entity)
        {
            _db.Suppliers.Update(entity);
            return save();
           // throw new NotImplementedException();
        }
    }
}
