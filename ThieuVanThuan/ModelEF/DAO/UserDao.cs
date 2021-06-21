using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;    

namespace ModelEF.DAO
{
    public class UserDao
    {
        ThieuVanThuanContext db = null;
        public UserDao()
        {
            db = new ThieuVanThuanContext();    
        }
        public long Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(UserAccount entity)
        {
            try
            {
                var user = db.UserAccounts.Find(entity.ID);
                user.UserName = entity.UserName;
                user.PassWord = entity.PassWord;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
        public IEnumerable<UserAccount> ListAllPaging(int page,int pageSize)
        {
            return db.UserAccounts.OrderByDescending(x=>x.ID).ToPagedList(page, pageSize);
        }
        public UserAccount GetById(string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }
        public UserAccount ViewDetail(int id)
        {
            return db.UserAccounts.Find(id);
        }
        public bool Login(string username, string password)
        {
            var result = db.UserAccounts.Count(x => x.UserName == username && x.PassWord == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);              
                    db.UserAccounts.Remove(user);
                    db.SaveChanges();
                    return true;
               
               
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
