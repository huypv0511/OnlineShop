using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public void Add(ProductCategory entity)
        {
            db.ProductCategory.Add(entity);
            db.SaveChanges();
        }
        public List<ProductCategory> ListProductCategory()
        {
            return db.ProductCategory.ToList();
        }
        public ProductCategory ViewDetail(long? id)
        {
            return db.ProductCategory.Find(id);
        }
    }
}
