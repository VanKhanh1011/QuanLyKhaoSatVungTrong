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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.DOTKHAOSATs = new HashSet<DOTKHAOSAT>();
        }
    
        public int MaNV { get; set; }
        public string Ten { get; set; }
        public Nullable<int> SDT { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> TT { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOTKHAOSAT> DOTKHAOSATs { get; set; }
    }
}