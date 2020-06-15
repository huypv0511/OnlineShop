using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public void Add(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();       
        }
        public List<User> ListUser()
        {
            return db.User.ToList();
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }
        public int Delete(int id)
        {
            User pro = db.User.Find(id);
            if (pro != null)
            {
                db.User.Remove(pro);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        public bool Update(User entity, int? id)
        {
            try
            {
                var user = db.User.Find(id);
                user.SDT = entity.SDT;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Fullname = entity.Fullname;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
        public User GetByUserName(string userName)
        {
            return db.User.SingleOrDefault(x => x.Username == userName);
        }public User GetByEmail(string Email)
        {
            return db.User.SingleOrDefault(x => x.Email == Email);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.User.Count(x => x.Username == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
