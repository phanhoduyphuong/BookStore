using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private BookStoreEntities db = new BookStoreEntities();

        // GET: Book
        public ActionResult Index()
        {
            var sACH = db.SACH.Include(s => s.THE_LOAI_SACH);
            return View(sACH.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.ID_THE_LOAI = new SelectList(db.THE_LOAI_SACH, "ID", "TEN_THE_LOAI");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEN_SACH,TAC_GIA,NHA_XB,GIA_TIEN,SO_LUONG,HINH_ANH,ID_THE_LOAI")] SACH sACH, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Photos"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    sACH.HINH_ANH = file.FileName;
                }                
                db.SACH.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_THE_LOAI = new SelectList(db.THE_LOAI_SACH, "ID", "TEN_THE_LOAI", sACH.ID_THE_LOAI);
            return View(sACH);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_THE_LOAI = new SelectList(db.THE_LOAI_SACH, "ID", "TEN_THE_LOAI", sACH.ID_THE_LOAI);
            return View(sACH);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TEN_SACH,TAC_GIA,NHA_XB,GIA_TIEN,SO_LUONG,ID_THE_LOAI")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_THE_LOAI = new SelectList(db.THE_LOAI_SACH, "ID", "TEN_THE_LOAI", sACH.ID_THE_LOAI);
            return View(sACH);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH sACH = db.SACH.Find(id);
            db.SACH.Remove(sACH);
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
    }
}
