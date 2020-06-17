using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using MVCDemo.Areas.Admin.Models;
using MVCDemo.Common;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var daocate = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(daocate.ListProductCategory(), "ID", "NAME", selectedId);
        }
        public ActionResult ListProduct()
        {
            var daocate = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(daocate.ListProductCategory(), "ID", "NAME");
            var dao = new ProductDao();
            var lst = dao.ListProduct();
            return View(lst);
        }
        public ActionResult Edit(int id)
        {
            var prod = new ProductDao().ViewDetail(id);
            var prodcate = new ProductCategoryDao().ViewDetail(prod.CategoryID);
            SetViewBag(prodcate.Name);
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(Product prod, int id, HttpPostedFileBase imgfile)
        {
            var dao = new ProductDao();
            var imgPath = Encryption.SaveImg(imgfile);
            var imgsrc = "/Content/images/hoaqua/"+imgPath;
            var result = dao.Update(prod, id,imgsrc);
            if (result)
            {
                return Json(new { isok = true, message = "Your Message" });
                //return RedirectToAction("ListUser", "Admin");
            }
            else
            {
                return Json(new { isok = false, message = "Your Message" });
            }
        }
        public void SetViewBag(string selectedId)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListProductCategory(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            var dao = new ProductDao();
            var check = dao.ViewDetail(id);
            if (check.ViewCount == 0)
            {
                dao.Delete(id);
                //return RedirectToAction("ListProduct", "Product");
                return Json(new { isok = true, message = "Your Message" });
            }
            else {
                //return RedirectToAction("ListProduct", "Product");
                return Json(new { isok = false, message = "Your Message" });
            }
        }

    }
}