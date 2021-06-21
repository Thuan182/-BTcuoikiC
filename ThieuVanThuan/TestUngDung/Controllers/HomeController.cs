using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        ThieuVanThuanContext db = new ThieuVanThuanContext();
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.Products.OrderByDescending(x => x.ID).Take(8).ToList();
            return View();
        }

     

        public ActionResult SanPhamMoi()
        {
            ViewBag.TrangSanPhamMoi = db.Products.OrderByDescending(x => x.ID).Take(10000).ToList();
            return View();
        }
        public ActionResult Detailes(int id)
        {
            //Tìm sản phẩm có mã sản phẩm = id
            Product sp = db.Products.SingleOrDefault(x => x.ID == id);
            //Nếu không tìm thấy
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}