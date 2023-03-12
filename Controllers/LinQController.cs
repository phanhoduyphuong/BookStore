using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LinQController : Controller
    {
        // GET: LinQ
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index()
        {
            List<SACH> result = db.SACH.OrderBy(s => s.ID_THE_LOAI).ToList();
                 
            return View(result);
        }
        [HttpPost]
        public ActionResult Search()
        {
            var search = Request.Form["search"];
            var price =  Convert.ToInt32(Request.Form["price"]);
            List<SACH> result = db.SACH.Where(b=>b.TEN_SACH.Contains(search) &&
                                b.GIA_TIEN >= price).ToList();

            return View("Index",result);
        }
        [ChildActionOnly]
        public ActionResult MinPrice()
        {
            string s = db.SACH.Min(b => b.GIA_TIEN).ToString();
            return Content(s);
        }
    }
}