using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeGuvCase.BLL.SingletonDesingPattern;
using TepeGuvCase.DAL;

namespace TepeGuvCase.BLL
{
    public class ProductDAL
    {
        TepeGuvCaseDbEntities _db = DbInstance.Instance;//Singleton
        public void Add(Product product)
        {
            _db.Entry(product).State = EntityState.Added;
            _db.SaveChanges();
        }
        public int Update(Product product)
        {
           
            _db.Entry(product).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public int Delete(Product product)
        {
            _db.Entry(product).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();

        }

        public Product GetByID(int productID)
        {
            return _db.Products.FirstOrDefault(x => x.ID == productID);
        }

    }
}
