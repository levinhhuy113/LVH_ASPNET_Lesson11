using LvhK22CNTLesson11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LvhK22CNTLesson11.Controllers
{
    public class LvhHomeController : Controller
    {
        public ActionResult LvhIndex()
        {
            // lấy thông tin từ session
            //ViewBag["LvhTaiKhoan"] = "";
            if (Session["LvhMember"] != null)
            {
                ViewBag.LvhTaiKhoan = ((LvhTaiKhoan)Session["LvhMember"]).LvhFullName;
            }
            return View();
        }

        public ActionResult LvhAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LvhContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}