using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TepeGuvCase.BLL.SingletonDesingPattern;
using TepeGuvCase.DAL;

namespace TepeGuvCase.BLL.Service
{
    public class EntityCore<T> where T : class
    {
        TepeGuvCaseDbEntities _db = DbInstance.Instance;//Singleton
        public void Add(T item)
        {
            _db.Set(typeof(T)).Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var Deleted = _db.Set(typeof(T)).Find(id);
            _db.Set(typeof(T)).Remove(Deleted);
            _db.SaveChanges();
        }
        public List<T> SelectAll()
        {
            return _db.Set(typeof(T)).Cast<T>().ToList();
        }
       
        public T SelectByID(int id)
        {
            return _db.Set(typeof(T)).Cast<T>().Find(id);
        }
        public void Update(T item)
        {
            #region Propertylerde Gezme ve lazım olanı alma işlemi
            PropertyInfo pinfo = null;
            foreach (PropertyInfo property in item.GetType().GetProperties())
            {
                //Bilinmeyen bir tipin icerisinde bulunan propertylere ulaşmayı sağlayan kod.
                if (property.Name == "ID")
                {
                    pinfo = property;
                }
            }
            #endregion
            var Guncellenecek = _db.Set(typeof(T)).Find(pinfo.GetValue(item));
            _db.Entry(Guncellenecek).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
