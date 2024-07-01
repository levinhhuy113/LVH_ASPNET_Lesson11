using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LvhK22CNTLesson11.Models;

namespace LvhK22CNTLesson11.Controllers
{
    public class LvhTaiKhoansController : Controller
    {
        private LvhLesson11DbsEntities db = new LvhLesson11DbsEntities();

        // GET: LvhTaiKhoans
        public ActionResult Index()
        {
            return View(db.LvhTaiKhoans.ToList());
        }

        // GET: LvhTaiKhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhTaiKhoan lvhTaiKhoan = db.LvhTaiKhoans.Find(id);
            if (lvhTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(lvhTaiKhoan);
        }

        // GET: LvhTaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LvhTaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LvhId,LvhUserName,LvhPassword,LvhFullName,LvhAge,LvhEmail,LvhPhone,LvhStatus")] LvhTaiKhoan lvhTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.LvhTaiKhoans.Add(lvhTaiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lvhTaiKhoan);
        }

        // GET: LvhTaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhTaiKhoan lvhTaiKhoan = db.LvhTaiKhoans.Find(id);
            if (lvhTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(lvhTaiKhoan);
        }

        // POST: LvhTaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LvhId,LvhUserName,LvhPassword,LvhFullName,LvhAge,LvhEmail,LvhPhone,LvhStatus")] LvhTaiKhoan lvhTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhTaiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lvhTaiKhoan);
        }

        // GET: LvhTaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhTaiKhoan lvhTaiKhoan = db.LvhTaiKhoans.Find(id);
            if (lvhTaiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(lvhTaiKhoan);
        }

        // POST: LvhTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LvhTaiKhoan lvhTaiKhoan = db.LvhTaiKhoans.Find(id);
            db.LvhTaiKhoans.Remove(lvhTaiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // Form đăng nhập hệ thống
        public ActionResult LvhLogin()
        {
            var LvhModel = new LvhLoginModel();
            return View(LvhModel);
        }

        [HttpPost]
        public ActionResult LvhLogin(LvhLoginModel LvhModel)
        {
            // khi người dùng nhấn nút đăng nhập; xử lý và tìm kiến, so sanh trong db

            var LvhCheckLogin = db.LvhTaiKhoans.Where(x => x.LvhUserName.Equals(LvhModel.LvhUserName) && x.LvhPassword.Equals(LvhModel.LvhPassword)).FirstOrDefault();
            if (LvhCheckLogin != null)
            {
                //Lưu trữ session
                Session["LvhMember"] = LvhCheckLogin;

                return Redirect("/");
            }
            return View(LvhModel);
        }
        public ActionResult Logout()
        {
            Session.Remove("LvhMember");
            return Redirect("/");
        }
    }
}
