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
    
    public partial class VUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VUON()
        {
            this.QUYENSOHUUs = new HashSet<QUYENSOHUU>();
        }
    
        public int MaVuon { get; set; }
        public string TenVuon { get; set; }
        public Nullable<int> MaKT { get; set; }
        public Nullable<int> MaDKST { get; set; }
        public Nullable<int> MaCT { get; set; }
        public Nullable<int> MaLD { get; set; }
        public Nullable<int> MaHT { get; set; }
        public Nullable<int> MaDP { get; set; }
        public Nullable<double> DienTich { get; set; }
    
        public virtual CAYTRONG CAYTRONG { get; set; }
        public virtual DIAPHUONG DIAPHUONG { get; set; }
        public virtual DIEUKIENSINHTHAI DIEUKIENSINHTHAI { get; set; }
        public virtual HIENTRANG HIENTRANG { get; set; }
        public virtual KYTHUATCANHTAC KYTHUATCANHTAC { get; set; }
        public virtual LOAIDAT LOAIDAT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUYENSOHUU> QUYENSOHUUs { get; set; }
    }
}