using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var productDao = new ProductDao();
            var model = productDao.List(searchString);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Detais(int id)
        {
            var dao = new ProductDao();
            var rs = dao.Find(id);
            SetViewBag(rs.CategoryID);
            return View(rs);

        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product id)
        {
            SetViewBag();

            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long rs = dao.Insert(id);
                if (rs>0)
                {         
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thành công");
                }
            }
            return View("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var dao = new ProductDao();
            var rs = dao.Find(id);
            SetViewBag(rs.CategoryID);
            return View(rs);

        }
        [HttpPost]

        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");

        }
        public void SetViewBag(long? selectedid = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedid);
        }
    }
}