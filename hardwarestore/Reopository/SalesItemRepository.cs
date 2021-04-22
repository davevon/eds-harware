using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hardwarestore.Contracts;
using hardwarestore.Data;

namespace hardwarestore.Reopository
{
    public class SalesItemRepository : ISalesRepository
    {
        private readonly ApplicationDbContext _db;// the databease in initialise in the programm

        public SalesItemRepository(ApplicationDbContext db)// paassing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }
        public bool Create(SalesItem entity)
        {
            _db.SalesItems.Add(entity);
            return save();

        }

        public bool Delete(SalesItem entity)
        {
            _db.SalesItems.Remove(entity);
            return save();
        }

        public ICollection<SalesItem> FindAll()
        {
            _db.SalesItems.ToList(); ;
            return _db.SalesItems.ToList();
        }

        public SalesItem FindById(int id)
        {
            _db.SalesItems.Find(id);
            return _db.SalesItems.Find(id);
        }

        public ICollection<SalesItem> GetSalesByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.SalesItems.Any(q => q.SalesItemId == id);
                return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(SalesItem entity)
        {
            _db.SalesItems.Update(entity);
            return save();
        }
    }
}
