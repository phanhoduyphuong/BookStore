using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private BookStoreEntities db = new BookStoreEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddBook(int id)
        {
            SACH s = db.SACH.Find(id);
            var Cart = Session["ShoppingCart"] as ShoppingCart;
            if (Cart == null)
            {
                Cart = new ShoppingCart();
                Cart.AddCart(s);              
            }
            else
            {                
                Cart.AddCart(s);                
            }
            Session["ShoppingCart"] = Cart;
            return View("Index");
        }
        public ActionResult DeleteAll()
        {
            Session["ShoppingCart"] = null;
            return View("Index");
        }
    }
}