using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public void Add(Category entity)
        {
            db.Category.Add(entity);
            db.SaveChanges();
        }
        public List<Category> ListCategory()
        {
            return db.Category.ToList();
        }
        public Category ViewDetail(long? id)
        {
            return db.Category.Find(id);
        }

    }
}
