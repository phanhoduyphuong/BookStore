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
    
    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            this.HOA_DON = new HashSet<HOA_DON>();
        }
    
        public int ID { get; set; }
        public string TEN_KH { get; set; }
        public string SĐT { get; set; }
        public string ĐIA_CHI { get; set; }
        public string GHI_CHU { get; set; }
        public Nullable<System.DateTime> NGAY_SINH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
    }
}
