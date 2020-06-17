using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Common
{
    public static class Encryption
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        public static string SaveImg(HttpPostedFileBase imgfile)
        {
            if (imgfile != null && imgfile.ContentLength > 0)
            {
                string imgname = Path.GetFileName(imgfile.FileName);
                string imgext = Path.GetExtension(imgname);
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images/hoaqua"), imgname);
                imgfile.SaveAs(imgpath);
                return imgname;
            }
            else {
                return null;
            }
        }
    }
}