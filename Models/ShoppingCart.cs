using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        public List<SACH> BookList { get; set; }        
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
                BookList.Add(s);
                return true;
            }
                
        }
    }
}