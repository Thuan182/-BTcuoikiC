using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using PagedList;
using ModelEF.Model;
namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new CategoryDao();
            var model = user.List(searchString);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public ActionResult Detais(int id)
        {
            var dao = new CategoryDao();
            var rs = dao.Find(id);
            return View(rs);

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new CategoryDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category id)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                long rs = dao.Insert(id);
                if (rs>0)
                {
                
                    return RedirectToAction("Index", "Category");

                }
                else        
                {
                    ModelState.AddModelError("", "Thêm thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(category);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
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
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");

        }


    }
}