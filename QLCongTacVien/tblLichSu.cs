//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLCongTacVien
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLichSu
    {
        public tblLichSu()
        {
            this.tblKhachHangs = new HashSet<tblKhachHang>();
        }
    
        public long MaLichSu { get; set; }
        public string NoiDung { get; set; }
        public Nullable<double> GiaTri { get; set; }
        public string GhiChu1 { get; set; }
        public string GhiChu2 { get; set; }
        public string GhiChu3 { get; set; }
        public string GhiChu4 { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgayUpdate { get; set; }
        public Nullable<System.DateTime> UserTao { get; set; }
        public Nullable<System.DateTime> UserUpdate { get; set; }
    
        public virtual ICollection<tblKhachHang> tblKhachHangs { get; set; }
    }
}
