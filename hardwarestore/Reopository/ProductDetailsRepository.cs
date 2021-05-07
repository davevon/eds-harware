using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hardwarestore.Contracts;
using hardwarestore.Data;

namespace hardwarestore.Reopository
{
    
    public class ProductDetailsRepository : IProductDetailsRepository
    
    { private readonly ApplicationDbContext _db;// the databease in initialise in the programm

        public ProductDetailsRepository(ApplicationDbContext db)// paassing the database inside the parameter 
        {
            _db = db;// passing an object inside the so we can get the information for the database.
        }

        public bool Create(ProductDetail entity)
        {
            _db.ProdDetails.Add(entity);
            return save();

           // throw new NotImplementedException();
        }

        public bool Delete(ProductDetail entity)
        {
            _db.ProdDetails.Remove(entity);
            return save();
            //throw new NotImplementedException();
        }

        public ICollection<ProductDetail> FindAll()
        {
            _db.ProdDetails.ToList();
            return _db.ProdDetails.ToList();
            //throw new NotImplementedException();
        }

        public ProductDetail FindById(int id)
        {
            _db.ProdDetails.Find(id);
            return _db.ProdDetails.Find(id);
            //throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exist = _db.ProdDetails.Any(q => q.ProductId == id);
            return exist;
        }

        public bool save()
        {
            return _db.SaveChanges() > 0;
           // throw new NotImplementedException();
        }

        public bool Update(ProductDetail entity)
        {
            _db.ProdDetails.Update(entity);
            return save();
            //throw new NotImplementedException();
        }
    }
}
