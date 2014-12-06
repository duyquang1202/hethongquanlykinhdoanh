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
        public tblAccount getDanhSachUser(long MaAccount, string sTenUser, string sField, string sSort)
        {
            tblAccount objUser = new tblAccount();

            try
            {
                var predicate = PredicateBuilder.True<tblUser>();

                if (!String.IsNullOrEmpty(sTenUser))
                {

                    predicate = predicate.And(m => m.UserName.ToLower().Contains(sTenUser.ToLower()));
                }



                var p = Expression.Parameter(typeof(tblUser));

                Func<tblUser, object> SortBy = Expression.Lambda<Func<tblUser, dynamic>>(Expression.TypeAs(Expression.Property(p, sField), typeof(object)), p).Compile();

                SqlOrderByDirecton SortOrder = (SqlOrderByDirecton)Enum.Parse(typeof(SqlOrderByDirecton), sSort, true);

                objUser = DbContext.tblAccounts.Find(MaAccount);
                if (objUser != null)
                {

                    var lst = objUser.tblUsers.Where(predicate.Compile());
                    if (sSort.ToLower() == "asc")
                    {
                        objUser.tblUsers = lst.OrderBy(SortBy).AsEnumerable().ToList();

                    }
                    else
                    {
                        objUser.tblUsers = lst.OrderByDescending(SortBy).AsEnumerable().ToList();

                    }
                }

                return objUser;
            }
            catch (Exception obj)
            {

                throw;
            }

            return objUser;
        }

        public tblAccount getDanhSachUserSameAccount(long MaUser, string sTenUser, string sField, string sSort)
        {
            tblAccount objUser = new tblAccount();

            try
            {
                var predicate = PredicateBuilder.True<tblUser>();

                if (!String.IsNullOrEmpty(sTenUser))
                {

                    predicate = predicate.And(m => m.UserName.ToLower().Contains(sTenUser.ToLower()));
                }
                predicate = predicate.And(m => m.tblAccounts.Any(a => a.tblUsers.Any(u => u.MaUser == MaUser)));



                var p = Expression.Parameter(typeof(tblUser));

                Func<tblUser, object> SortBy = Expression.Lambda<Func<tblUser, dynamic>>(Expression.TypeAs(Expression.Property(p, sField), typeof(object)), p).Compile();

                SqlOrderByDirecton SortOrder = (SqlOrderByDirecton)Enum.Parse(typeof(SqlOrderByDirecton), sSort, true);



                var lst = DbContext.tblUsers.Where(predicate.Compile());
                if (sSort.ToLower() == "asc")
                {
                    objUser.tblUsers = lst.OrderBy(SortBy).AsEnumerable().ToList();

                }
                else
                {
                    objUser.tblUsers = lst.OrderByDescending(SortBy).AsEnumerable().ToList();

                }


                return objUser;
            }
            catch (Exception obj)
            {

                throw;
            }

            return objUser;
        }

        public bool TaoUser(tblUser model, long MaAccount)
        {
            try
            {
                var account = DbContext.tblAccounts.Find(MaAccount);

                model.tblAccounts.Add(account);

                DbContext.tblUsers.Add(model);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception obj)
            {
                return false;
            }

        }

        public tblUser getUser(string UserName)
        {
            try
            {
                return DbContext.tblUsers.Where(m => m.UserName.ToLower() == UserName.ToLower()).First();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public tblUser getUser(long MaUser)
        {
            try
            {
                return DbContext.tblUsers.Find(MaUser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public tblUser getEmail(string Email)
        {
            try
            {
                return DbContext.tblUsers.Where(m => m.Email.ToLower() == Email.ToLower()).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public tblUser getOneUser(long id)
        {

            try
            {
                tblUser objResponse = DbContext.tblUsers.Find(id);
                return objResponse;
            }
            catch (Exception obj)
            {
                return null;
            }

        }

        public bool UpdateUser(tblUser model)
        {
            try
            {

                tblUser update = DbContext.tblUsers.Find(model.MaUser);
                update.UserName = model.UserName;
                update.GhiChu = model.GhiChu;
                update.Email = model.Email;
                update.FullName = model.FullName;
                update.DienThoai = model.DienThoai;
                update.DiaChi = model.DiaChi;
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

        public bool ActiveUser(long MaUser, long MaAccount, int Status)
        {
            try
            {
                tblUser update = DbContext.tblUsers.Find(MaUser);
                if (Status == 0)
                {
                    Status = 1;
                }
                else
                {
                    Status = 0;
                }
                if (update == null)
                {
                    return false;
                }
                if (update.tblAccounts.Count() > 1)
                {
                    tblAccount account = DbContext.tblAccounts.Find(MaAccount);
                    update.tblAccounts.Remove(account);

                }
                else
                {
                    update.TrangThai = Status;
                }

                DbContext.SaveChanges();
                return true;
            }
            catch (Exception obj)
            {
                return false;
            }

        }

        public bool XoaUser(string[] lstId, long MaAccount)
        {
            try
            {
                tblAccount account = DbContext.tblAccounts.Find(MaAccount);

                foreach (var item in lstId)
                {

                    var users = account.tblUsers.Where(m => m.MaUser == Convert.ToInt64(item));
                    foreach (var user in users.ToList())
                    {
                        DbContext.tblUsers.Remove(user);
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

    }
    public class UserModel
    {
        public MvcPaging.IPagedList<tblUser> ListUser { get; set; }
        public tblAccount Account { get; set; }

        public string sTenUser { get; set; }

        public long MaPhongBan { get; set; }
    }

    public class tblUserOver : tblUser
    {
        [Required(ErrorMessage = "Tên Account không được để trống")]
        [Display(Name = "Tên Đăng Nhập")]
        [Remote("doesUserNameExist", "User", AdditionalFields = "MaUser", HttpMethod = "POST", ErrorMessage = "UserName đã tồn tại. Vui lòng chọn một UserName khác.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có độ dài từ {2} - {0} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác Nhận Mật Khẩu")]
        [StringLength(100, ErrorMessage = "Xác nhận mật khẩu phải có độ dài từ {2} - {0} ký tự.", MinimumLength = 6)]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [Display(Name = "Họ Tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Điện thoại không được để trống")]
        [Display(Name = "Điện Thoại")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không hợp lệ, phải là chữ số.")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ.")]
        [Remote("doesEmailExist", "User", AdditionalFields = "MaUser", HttpMethod = "POST", ErrorMessage = "Email đã tồn tại. Vui lòng chọn một Email khác.")]
        [StringLength(30, MinimumLength = 2)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }
    }
}