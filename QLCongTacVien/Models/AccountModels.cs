using QLCongTacVien.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace QLCongTacVien.Models
{
    public partial class Process : BaseProcess
    {

        public CheckLogin CheckLogin(string strUserName, string strPassword)
        {
            var count = DbContext.tblUsers.Where(u => u.UserName == strUserName && u.Password == strPassword).Count();
            var ListUser = from u in DbContext.tblUsers.Where(
                                                              u => u.UserName == strUserName &&
                                                              u.Password == strPassword
                                                           )
                           select new
                           {
                               MaUser = u.MaUser,
                               UserName = u.UserName,
                           };


            if (ListUser.Count() > 0)
            {
                var aUser = ListUser.ToArray();
                return new CheckLogin
                {
                    bCheckLogin = true,
                    MaUser = aUser[0].MaUser,
                    UserName = aUser[0].UserName,
                    FullName = aUser[0].UserName
                };


            }
            return new CheckLogin
            {
                bCheckLogin = false
            };
        }

        public tblPhongBan getDanhSachAccount(long MaPhongBan, long? AccountParent, string sTenAccount, string LoaiAccount, string sField, string sSort, long MaUser)
        {
            tblPhongBan objPhongBan = new tblPhongBan();

            try
            {
                var predicate = PredicateBuilder.True<tblAccount>();

                if (!String.IsNullOrEmpty(sTenAccount))
                {

                    predicate = predicate.And(m => m.TenAccount.ToLower().Contains(sTenAccount.ToLower()));
                }
                var a = DbContext.tblUsers.Find(MaUser);
                var acc = a.tblAccounts.First();
                if (acc.LoaiAccount != "AD")
                {
                    predicate = predicate.And(m => m.tblUsers.Any(u => u.MaUser == MaUser));
                    var accc = DbContext.tblAccounts.Where(predicate.Compile());
                    foreach (var item in accc.ToList())
                    {
                        predicate = predicate.Or(m => m.AccountManager == item.MaAccount);
                    }
                }

                if (!String.IsNullOrEmpty(LoaiAccount))
                {
                    switch (LoaiAccount)
                    {
                        case "QL":
                            predicate = predicate.And(m => m.LoaiAccount == "KD");
                            predicate = predicate.Or(m => m.LoaiAccount == "CTV");

                            break;
                        default:
                            predicate = predicate.And(m => m.LoaiAccount == LoaiAccount);
                            break;
                    }

                }

                if (AccountParent != null)
                {
                    predicate = predicate.And(m => m.MaAccount == AccountParent);

                    predicate = predicate.Or(m => m.AccountManager == AccountParent);

                }


                var p = Expression.Parameter(typeof(tblAccount));

                Func<tblAccount, object> SortBy = Expression.Lambda<Func<tblAccount, dynamic>>(Expression.TypeAs(Expression.Property(p, sField), typeof(object)), p).Compile();

                SqlOrderByDirecton SortOrder = (SqlOrderByDirecton)Enum.Parse(typeof(SqlOrderByDirecton), sSort, true);

                objPhongBan = DbContext.tblPhongBans.Find(MaPhongBan);
                if (objPhongBan != null)
                {

                    var lst = objPhongBan.tblAccounts.Where(predicate.Compile());
                    if (sSort.ToLower() == "asc")
                    {
                        objPhongBan.tblAccounts = lst.OrderBy(SortBy).AsEnumerable().ToList();

                    }
                    else
                    {
                        objPhongBan.tblAccounts = lst.OrderByDescending(SortBy).AsEnumerable().ToList();

                    }
                }

                return objPhongBan;
            }
            catch (Exception obj)
            {

                throw;
            }

            return objPhongBan;
        }

        public bool TaoAccount(tblAccount model, long MaPhongBan)
        {
            try
            {
                var phongban = DbContext.tblPhongBans.Find(MaPhongBan);

                model.tblPhongBans.Add(phongban);

                DbContext.tblAccounts.Add(model);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception obj)
            {
                return false;
            }

        }

        public List<SelectListItem> getListAccountManager(long MaPhongBan)
        {
            List<SelectListItem> ListAccount = new List<SelectListItem>();
            try
            {
                var phongban = DbContext.tblPhongBans.Find(MaPhongBan);
                if (phongban != null)
                {
                    var accounts = phongban.tblAccounts.Where(
                                                          m => m.LoaiAccount == "QL"
                                                        );
                    foreach (var item in accounts.ToList())
                    {
                        ListAccount.Add(new SelectListItem() { Text = item.TenAccount, Value = item.MaAccount.ToString() });
                    }
                }

                return ListAccount;
            }
            catch (Exception obj)
            {
                return null;
            }
        }


        /**
         */
        public tblAccount getOneAccount(long id)
        {

            try
            {
                tblAccount objResponse = DbContext.tblAccounts.Find(id);
                return objResponse;
            }
            catch (Exception obj)
            {
                return null;
            }

        }

        public bool UpdateAccount(tblAccount model)
        {
            try
            {

                tblAccount update = DbContext.tblAccounts.Find(model.MaAccount);
                update.TenAccount = model.TenAccount;
                update.GhiChu = model.GhiChu;
                update.NgayUpdate = model.NgayUpdate;
                update.UserUpdate = model.UserUpdate;
                DbContext.SaveChanges();

                return true;
            }
            catch (Exception obj)
            {

                return false;
            }
        }

        public bool XoaAccount(string[] lstId, long MaPhongBan)
        {
            try
            {
                tblPhongBan phongban = DbContext.tblPhongBans.Find(MaPhongBan);

                foreach (var item in lstId)
                {
                    var accounts = phongban.tblAccounts.Where(m => m.MaAccount == Convert.ToInt64(item));
                    foreach (var account in accounts.ToList())
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

                }

                DbContext.SaveChanges();
            }
            catch (Exception obj)
            {

                throw new Exception(obj.Message);
            }


            return true;
        }



        public bool ActiveAccount(long MaAccount, int Status)
        {
            try
            {
                tblAccount update = DbContext.tblAccounts.Find(MaAccount);
                if (Status == 0)
                {
                    Status = 1;
                }
                else
                {
                    Status = 0;
                }

                foreach (var item in update.tblUsers.ToList())
                {
                    if (item.tblAccounts.Count() > 1)
                    {
                        update.tblUsers.Remove(item);
                    }
                    else
                    {
                        item.TrangThai = Status;
                        ActiveDeQuyAccount(update, Status);
                        update.TrangThai = Status;

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

        public tblAccount getAccount(string TenAccount)
        {
            try
            {
                return DbContext.tblAccounts.Where(m => m.TenAccount.ToLower() == TenAccount.ToLower()).First();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public tblAccount getAccount(long MaAccount)
        {
            try
            {
                return DbContext.tblAccounts.Find(MaAccount);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class AccountModel
    {
        public MvcPaging.IPagedList<tblAccount> ListAccount { get; set; }
        public string TenPhongBan { get; set; }
        public long MaPhongBan { get; set; }
        public string sTenAccount { get; set; }
    }

    public class CheckLogin
    {
        public long MaUser { get; set; }
        public string UserName { get; set; }
        public bool bCheckLogin { get; set; }
        public string FullName { get; set; }
    }
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {

        [Required(ErrorMessage = "Vui lòng nhập UserName hoặc Email.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Mật Khẩu.")]
        public string Password { get; set; }

        [Display(Name = "Nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class tblAccountOver : tblAccount
    {
        [Required(ErrorMessage = "Tên Account không được để trống")]
        [Display(Name = "Tên Account")]
        [Remote("doesTenAccountExist", "Account", AdditionalFields = "MaAccount", HttpMethod = "POST", ErrorMessage = "Tên Account đã tồn tại. Vui lòng chọn một tên khác.")]
        public string TenAccount { get; set; }

        [Display(Name = "Loại Account")]
        public string LoaiAccount { get; set; }

        [Display(Name = "Account Manager")]
        public Nullable<long> AccountManager { get; set; }

        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }

        public List<SelectListItem> ListAccountManager { get; set; }

        public tblAccount AccountManagerInfo { get; set; }
    }
}