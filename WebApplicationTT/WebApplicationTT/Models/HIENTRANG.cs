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
    
    public partial class HIENTRANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HIENTRANG()
        {
            this.VUONs = new HashSet<VUON>();
        }
    
        public int MaHT { get; set; }
        public Nullable<int> SoLuongCay { get; set; }
        public Nullable<double> NangSuat { get; set; }
        public string TiLe { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> TT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VUON> VUONs { get; set; }
    }
}
