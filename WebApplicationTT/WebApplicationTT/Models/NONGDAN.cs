//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationTT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NONGDAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NONGDAN()
        {
            this.QUYENSOHUUs = new HashSet<QUYENSOHUU>();
        }
    
        public int MaND { get; set; }
        public string HoTen { get; set; }
        public Nullable<int> SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MongMuon { get; set; }
        public string MatKhau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUYENSOHUU> QUYENSOHUUs { get; set; }
    }
}
