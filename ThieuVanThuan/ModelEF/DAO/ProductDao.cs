using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        ThieuVanThuanContext db = null;
        public ProductDao()
        {
            db = new ThieuVanThuanContext();
        }
        public long Insert(Product entity)
        {
            try
            {
                db.Products.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool Update(Product entity)
        {
            try
            {
                var user = db.Products.Find(entity.ID);
                user.Name = entity.Name;
                user.UnitCost = entity.UnitCost;
                user.Quantity = entity.Quantity;
                user.Image = entity.Image;
                user.Description = entity.Description;
                user.Status = entity.Status;
                user.CategoryID = entity.CategoryID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Product Find(int id)
        {
            return db.Products.Find(id);

        }
        public List<Product> ListAll()
        {

            return db.Products.ToList();
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> List(string searchString)
        {

            if (!string.IsNullOrEmpty(searchString))
                return db.Products.Where(x => x.Name.Contains(searchString) ||  x.UnitCost.ToString().Contains(searchString)
                || x.CategoryID.ToString().Contains(searchString)).OrderByDescending(x => x.UnitCost).ThenBy(x => x.CategoryID).ToList();
            return db.Products.OrderByDescending(x => x.UnitCost).ThenBy(x => x.CategoryID).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var ct = db.Products.Find(id);
                db.Products.Remove(ct);
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
