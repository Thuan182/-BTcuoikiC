using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;

namespace ModelEF.DAO
{

   public class CategoryDao
    {
        ThieuVanThuanContext db = null;
        public CategoryDao()
        {
            db = new ThieuVanThuanContext();
        }
        public long Insert(Category entity)
        {
            try
            {
                db.Categories.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool Update(Category entity)
        {
            try
            {
                var user = db.Categories.Find(entity.ID);
                user.Name = entity.Name;
                user.Description = entity.Description;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Category Find(int id)
        {
            return db.Categories.Find(id);

        }
        public List<Category> ListAll()
        {

            return db.Categories.ToList();
        }
        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
        public List<Category> List(string searchString)
        {

            if (!string.IsNullOrEmpty(searchString))
                return db.Categories.Where(x => x.Name.ToString().Contains(searchString) || x.ID.ToString().Contains(searchString)).ToList();
            return db.Categories.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var ct = db.Categories.Find(id);
                db.Categories.Remove(ct);
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
