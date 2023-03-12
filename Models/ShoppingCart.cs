using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        public List<SACH> BookList;    
        public ShoppingCart()
        {            
            BookList = new List<SACH>();
        }
        public decimal GetTotal()
        {
            decimal Total = 0;
            foreach(SACH b in BookList)
            {
                Total += Convert.ToInt32(b.GIA_TIEN);
            }
            return Total;
        }
        public bool AddCart(SACH s)
        {
            if (s == null)
                return false;
            else
            {
                s.SO_LUONG = 1;
                BookList.Add(s);
                return true;
            }
                
        }
        public bool Delete(SACH s)
        {
            if (s == null)
                return false;
            else
            {
                SACH book = BookList.Find(x => x.ID == s.ID) as SACH;                
                return BookList.Remove(book);
            }
        }
        public bool Update(int id, int soluong)
        {            
                SACH book = BookList.Find(x => x.ID == id) as SACH;
                book.SO_LUONG = soluong;
                return true;            
        }
    }
}