//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHI_TIET_HD
    {
        public int ID_HD { get; set; }
        public int ID_SACH { get; set; }
        public Nullable<double> GIA_TIEN { get; set; }
    
        public virtual HOA_DON HOA_DON { get; set; }
        public virtual SACH SACH { get; set; }
    }
}
