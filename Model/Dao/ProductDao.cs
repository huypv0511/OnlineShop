﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public void Add(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
        }
        public Product CheckName(string name)
        {
            return db.Product.SingleOrDefault(x => x.Name == name);
        }
        public List<Product> ListProduct()
        {
            return db.Product.ToList();
        }
        public Product ViewDetail(int id)
        {
            return db.Product.Find(id);
        }
        public int Delete(int id)
        {
            Product pro = db.Product.Find(id);
            if (pro != null)
            {
                db.Product.Remove(pro);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        public bool Update(Product entity, int? id,string imgsrc)
        {
            try
            {
                if (imgsrc != "/Content/images/hoaqua/")
                {
                    var pro = db.Product.Find(id);
                    pro.Name = entity.Name;
                    pro.CategoryID = entity.CategoryID;
                    pro.Price = entity.Price;
                    pro.PromotionPice = entity.PromotionPice;
                    pro.Image = imgsrc;
                    pro.Quantity = entity.Quantity;
                    pro.Description = entity.Description;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    var pro = db.Product.Find(id);
                    pro.Name = entity.Name;
                    pro.CategoryID = entity.CategoryID;
                    pro.Price = entity.Price;
                    pro.PromotionPice = entity.PromotionPice;
                    pro.Quantity = entity.Quantity;
                    pro.Description = entity.Description;
                    db.SaveChanges();
                    return true;
                }

               
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
