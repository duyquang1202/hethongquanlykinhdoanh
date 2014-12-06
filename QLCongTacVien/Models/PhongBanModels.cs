using QLCongTacVien.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QLCongTacVien.Models
{
    public partial class Process : BaseProcess
    {
        public bool UpdatePhongBan(PhongBanModel model)
        {
            try
            {

                tblPhongBan update = DbContext.tblPhongBans.Find(model.MaPhongBan);
                update.TenPhongBan = model.TenPhongBan;
                update.MoTaPhongBan = model.MoTaPhongBan;
                update.GhiChuPhongBan = model.GhiChuPhongBan;
                update.NgayUpdate = DateTime.Now;
                update.UserUpdate = model.UserUpdate;
                DbContext.SaveChanges();

                return true;
            }
            catch (Exception obj)
            {

                return false;
            }
        }

        public bool ActiveDeQuyAccount(tblAccount account, int Status)
        {
            try
            {
                tblAccount update = DbContext.tblAccounts.Find(account.MaAccount);


                foreach (var item in update.tblUsers.ToList())
                {
                    if (item.tblAccounts.Count() > 1)
                    {
                        update.tblUsers.Remove(item);
                    }
                    else
                    {
                        item.TrangThai = Status;
                        update.TrangThai = Status;

                    }
                }

                if (account.tblAccount1.Count <= 0)
                {
                    return true;
                }

                foreach (var acc in account.tblAccount1)
                {
                    ActiveDeQuyAccount(acc, Status);
                }



                DbContext.SaveChanges();
                return true;
            }
            catch (Exception obj)
            {
                throw new Exception(obj.Message);
                return false;
            }

        }

        public bool ActivePhongBan(long MaPhongBan, int Status)
        {
            try
            {
                tblPhongBan update = DbContext.tblPhongBans.Find(MaPhongBan);
                if (Status == 0)
                {
                    Status = 1;
                }
                else
                {
                    Status = 0;
                }
                update.TrangThai = Status;

                foreach (var item in update.tblAccounts.ToList())
                {
                    if (item.tblPhongBans.Count() > 1)
                    {
                        update.tblAccounts.Remove(item);
                    }
                    else
                    {
                        ActiveDeQuyAccount(item, Status);
                        item.TrangThai = Status;

                        foreach (var user in item.tblUsers.ToList())
                        {
                            var u = DbContext.tblUsers.Find(user.MaUser);
                            u.TrangThai = Status;
                        }
                    }

                }
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception obj)
            {
                return false;
            }

        }

        public PhongBanModel getOnePhongBan(long id)
        {
            PhongBanModel objResponse = new PhongBanModel();
            var k = DbContext.tblPhongBans.Find(id);
            try
            {
                if (k != null)
                {
                    objResponse.MaPhongBan = k.MaPhongBan;
                    objResponse.TenPhongBan = k.TenPhongBan;
                    objResponse.MoTaPhongBan = k.MoTaPhongBan;
                    objResponse.GhiChuPhongBan = k.GhiChuPhongBan;
                    objResponse.NgayTao = (DateTime)k.NgayTao;
                    objResponse.NgayUpdate = (DateTime)k.NgayUpdate;
                    objResponse.UserTao = k.UserTao;
                    objResponse.UserUpdate = k.UserUpdate;
                    objResponse.TrangThai = (int)k.TrangThai;

                }
            }
            catch (Exception obj)
            {
                return null;
            }
            return objResponse;
        }

        public bool TaoPhongBan(PhongBanModel model)
        {
            try
            {
                tblPhongBan objPhongBan = new tblPhongBan();
                objPhongBan.MaPhongBan = model.MaPhongBan;
                objPhongBan.TenPhongBan = model.TenPhongBan;
                objPhongBan.MoTaPhongBan = model.MoTaPhongBan;
                objPhongBan.GhiChuPhongBan = model.GhiChuPhongBan;
                objPhongBan.NgayTao = model.NgayTao;
                objPhongBan.NgayUpdate = model.NgayUpdate;
                objPhongBan.UserTao = model.UserTao;
                objPhongBan.UserUpdate = model.UserUpdate;
                objPhongBan.TrangThai = model.TrangThai;

                DbContext.tblPhongBans.Add(objPhongBan);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception obj)
            {
                return false;
            }

        }
        public enum SqlOrderByDirecton
        {
            ASC,
            DESC
        }
        public IList<PhongBanModel> GetDanhSachPhongBan(string sField, string sSort, string sTenPhongBan, long MaUser)
        {
            IList<PhongBanModel> lstPhongBan = new List<PhongBanModel>();
            try
            {

                List<tblPhongBan> lphongban = new List<tblPhongBan>();


                // get the expression from the sort field passed in

                var predicate = PredicateBuilder.True<tblPhongBan>();

                if (!String.IsNullOrEmpty(sTenPhongBan))
                {

                    predicate = predicate.And(m => m.TenPhongBan.ToLower().Contains(sTenPhongBan.ToLower()));
                }


                var a = DbContext.tblUsers.Find(MaUser);
                var acc = a.tblAccounts.First();
                if (acc.LoaiAccount == "AD")
                {
                    // predicate = predicate.And(m => m.tblAccounts.Any(x => x.LoaiAccount != acc.LoaiAccount));
                }
                else
                {
                    predicate = predicate.And(m => m.tblAccounts.Any(x => x.tblUsers.Any(u => u.MaUser == MaUser)));
                    // var t = item.tblAccounts.Where(m => m.tblUsers.Any(u => u.MaUser == MaUser));
                }
                var lst = DbContext.tblPhongBans.Where(predicate.Compile());
                foreach (var item in lst.ToList())
                {
                    var itemacc = item.tblAccounts.Where(m => m.LoaiAccount == "AD");
                    if (itemacc.Count() == 0)
                    {
                        lphongban.Add(item);
                    }
                }
                var lstResult = new List<tblPhongBan>();

                var p = Expression.Parameter(typeof(tblPhongBan));

                Func<tblPhongBan, object> SortBy = Expression.Lambda<Func<tblPhongBan, dynamic>>(Expression.TypeAs(Expression.Property(p, sField), typeof(object)), p).Compile();

                SqlOrderByDirecton SortOrder = (SqlOrderByDirecton)Enum.Parse(typeof(SqlOrderByDirecton), sSort, true);


                if (sSort.ToLower() == "asc")
                {
                    lstResult = lphongban.OrderBy(SortBy).AsEnumerable().ToList();
                }
                else
                {
                    lstResult = lphongban.OrderByDescending(SortBy).AsEnumerable().ToList();
                }
                foreach (var item in lstResult)
                {
                    PhongBanModel objPhongBan = new PhongBanModel();
                    objPhongBan.MaPhongBan = item.MaPhongBan;
                    objPhongBan.TenPhongBan = item.TenPhongBan;
                    objPhongBan.MoTaPhongBan = item.MoTaPhongBan;
                    objPhongBan.GhiChuPhongBan = item.GhiChuPhongBan;
                    objPhongBan.NgayTao = (DateTime)item.NgayTao;
                    objPhongBan.NgayUpdate = (DateTime)item.NgayUpdate;
                    objPhongBan.UserTao = item.UserTao;
                    objPhongBan.UserUpdate = item.UserUpdate;
                    objPhongBan.TrangThai = (int)item.TrangThai;
                    lstPhongBan.Add(objPhongBan);
                }
                return lstPhongBan;
            }
            catch (Exception obj)
            {

                throw new Exception("Co Loi Trong Qua Trinh Xu Ly");
            }
            return lstPhongBan;
        }

        public bool XoaPhongBan(string[] lstId)
        {
            try
            {
                foreach (var item in lstId)
                {
                    tblPhongBan phongban = DbContext.tblPhongBans.Find(Convert.ToInt64(item));
                    foreach (var account in phongban.tblAccounts.ToList())
                    {

                        foreach (var nhom in account.tblNhoms.ToList())
                        {
                            foreach (var khachhang in nhom.tblKhachHangs.ToList())
                            {

                                foreach (var lichsu in khachhang.tblLichSus.ToList())
                                {
                                    DbContext.tblLichSus.Remove(lichsu);
                                }

                                DbContext.tblKhachHangs.Remove(khachhang);
                            }
                            DbContext.tblNhoms.Remove(nhom);
                        }
                        foreach (var user in account.tblUsers.ToList())
                        {
                            DbContext.tblUsers.Remove(user);
                        }

                        foreach (var account1 in account.tblAccount1.ToList())
                        {

                            foreach (var nhom1 in account1.tblNhoms.ToList())
                            {
                                foreach (var khachhang1 in nhom1.tblKhachHangs.ToList())
                                {

                                    foreach (var lichsu1 in khachhang1.tblLichSus.ToList())
                                    {
                                        DbContext.tblLichSus.Remove(lichsu1);
                                    }
                                    DbContext.tblKhachHangs.Remove(khachhang1);
                                }
                                DbContext.tblNhoms.Remove(nhom1);
                            }
                            foreach (var user1 in account1.tblUsers.ToList())
                            {
                                DbContext.tblUsers.Remove(user1);
                            }
                            DbContext.tblAccounts.Remove(account1);

                        }

                        DbContext.tblAccounts.Remove(account);

                    }
                    DbContext.tblPhongBans.Remove(phongban);
                }
                DbContext.SaveChanges();
            }
            catch (Exception obj)
            {
                throw new Exception(obj.Message);
                return false;
            }


            return true;
        }
    }
    public class NotificationModel
    {
        public bool ShowError;
        public string Message;
    }
    public class ListPhongBanModel
    {
        public List<PhongBanModel> ListPhongBan { get; set; }
    }
    public class PhongBanModel
    {
        public long MaPhongBan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phòng ban")]
        [Display(Name = "Tên Phòng Ban")]
        public string TenPhongBan { get; set; }

        [Display(Name = "Mô Tả Phòng Ban")]
        public string MoTaPhongBan { get; set; }

        [Display(Name = "Ghi Chú Phòng Ban")]
        public string GhiChuPhongBan { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime NgayUpdate { get; set; }
        public string UserTao { get; set; }
        public string UserUpdate { get; set; }
        public int TrangThai { get; set; }

    }

    public class LstPhongBanModel
    {
        public MvcPaging.IPagedList<PhongBanModel> ListPhongBan { get; set; }

        public string sTenPhongBan { get; set; }
    }
}