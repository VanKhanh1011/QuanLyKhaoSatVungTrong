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
    
    public partial class HETHONGTUOI
    {
        public int MaHTT { get; set; }
        public string PhuongThuc { get; set; }
        public string NguonNuoc { get; set; }
        public Nullable<int> MaKT { get; set; }
    
        public virtual KYTHUATCANHTAC KYTHUATCANHTAC { get; set; }
    }
}