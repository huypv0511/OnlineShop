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
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListUser()
        {
            var dao = new UserDao();
            var lst = dao.ListUser();
            return View(lst);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            dao.Delete(id);
            return RedirectToAction("ListUser", "Admin");
        }
        [HttpPost]
        public ActionResult Edit(User user, int? id)
        {
            var dao = new UserDao();
            if (!string.IsNullOrEmpty(user.Password))
            {
                var encryptedMd5Pas = Encryption.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
            }
            if (user.Address == null || user.Email == null || user.Fullname == null || user.SDT == null)
            {
                return Json(new { isok = false, message = "Your Message" });
            }
            else {
                var result = dao.Update(user, id);
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
        }
    }
}