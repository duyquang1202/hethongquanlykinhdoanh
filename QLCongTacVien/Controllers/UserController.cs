using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using QLCongTacVien.Models;
using QLCongTacVien.Infrastructure;
namespace QLCongTacVien.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachUser(long MaAccount, string sField, string sSort, int? page, int? pagesize, string sTenUser)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = sField != null ? sField : "UserName";
            sSort = sSort != null ? sSort : "ASC";


            tblAccount objAccount = pro.getDanhSachUser(MaAccount, sTenUser, sField, sSort);
            UserModel model = new UserModel();

            model.ListUser = objAccount.tblUsers.ToList().ToPagedList(currentPageIndex, currentPageSize);
            model.Account = objAccount;
            model.MaPhongBan = objAccount.tblPhongBans.First().MaPhongBan;
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            model.sTenUser = sTenUser;
            ViewBag.MaAccount = MaAccount;
            return PartialView("DanhSachUser", model);
        }
        public ActionResult DanhSachUserSameAccount(long MaUser, string sField, string sSort, int? page, int? pagesize, string sTenUser)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = sField != null ? sField : "UserName";
            sSort = sSort != null ? sSort : "ASC";


            tblAccount objAccount = pro.getDanhSachUserSameAccount(MaUser, sTenUser, sField, sSort);
            UserModel model = new UserModel();

            model.ListUser = objAccount.tblUsers.ToList().ToPagedList(currentPageIndex, currentPageSize);
            model.Account = objAccount;
            model.MaPhongBan = objAccount.tblUsers.First().tblAccounts.First().tblPhongBans.First().MaPhongBan;
            //model.MaPhongBan = objAccount.tblPhongBans.First().MaPhongBan;
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            model.sTenUser = sTenUser;
            ViewBag.MaUser = MaUser;
            // ViewBag.MaAccount = MaAccount;
            return PartialView("DanhSachUserSameAccount", model);
        }

        public ActionResult DanhSachUserSameAccountSearch(long MaUser, string sField, string sSort, int? page, int? pagesize, string sTenUser)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = sField != null ? sField : "UserName";
            sSort = sSort != null ? sSort : "ASC";


            tblAccount objAccount = pro.getDanhSachUserSameAccount(MaUser, sTenUser, sField, sSort);
            UserModel model = new UserModel();

            model.ListUser = objAccount.tblUsers.ToList().ToPagedList(currentPageIndex, currentPageSize);
            model.Account = objAccount;
            model.MaPhongBan = objAccount.tblUsers.First().tblAccounts.First().tblPhongBans.First().MaPhongBan;
            //model.MaPhongBan = objAccount.tblPhongBans.First().MaPhongBan;
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            model.sTenUser = sTenUser;
            ViewBag.MaUser = MaUser;
            // ViewBag.MaAccount = MaAccount;
            return PartialView("DanhSachUserSameAccountSearch", model);
        }

        public ActionResult DanhSachUserSearch(long MaAccount, string sField, string sSort, int? page, int? pagesize, string sTenUser)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = sField != null ? sField : "UserName";
            sSort = sSort != null ? sSort : "ASC";


            tblAccount objAccount = pro.getDanhSachUser(MaAccount, sTenUser, sField, sSort);
            UserModel model = new UserModel();
            if (objAccount != null)
            {
                model.ListUser = objAccount.tblUsers.ToList().ToPagedList(currentPageIndex, currentPageSize);
                model.Account = objAccount;
            }

            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            model.sTenUser = sTenUser;
            return PartialView("DanhSachUserSearch", model);
        }

        [HttpGet]
        public ActionResult TaoUser(long MaAccount, string TenAccount, string sField, string sSort, int page, int pagesize)
        {
            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.MaAccount = MaAccount;
            ViewBag.TenAccount = TenAccount;
            return View();
        }

        [HttpGet]
        public ActionResult TaoUserSameAccount(long MaUser, long MaAccount, string TenAccount, string sField, string sSort, int page, int pagesize)
        {
            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.MaUser = MaUser;
            ViewBag.MaAccount = MaAccount;
            ViewBag.TenAccount = TenAccount;
            return View();
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string UserName, long MaUser = 0)
        {
            tblUser user = null;
            if (MaUser != 0)
            {
                var userinfo = pro.getUser(MaUser);
                if (userinfo != null)
                {
                    if (userinfo.UserName != UserName)
                    {
                        user = pro.getUser(UserName);

                    }

                }
            }
            else
            {
                user = pro.getUser(UserName);
            }


            return Json(user == null);
        }

        [HttpPost]
        public JsonResult doesEmailExist(string Email, long MaUser = 0)
        {
            tblUser user = null;
            if (MaUser != 0)
            {
                var userinfo = pro.getUser(MaUser);
                if (userinfo != null)
                {
                    if (userinfo.Email != Email)
                    {
                        user = pro.getEmail(Email);

                    }

                }
            }
            else
            {
                user = pro.getEmail(Email);
            }


            return Json(user == null);

        }

        [HttpPost]
        public ActionResult TaoUser(tblUser model, long MaAccount)
        {
            model.MaUser = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            model.NgayTao = DateTime.Now;
            model.NgayUpdate = DateTime.Now;
            SessionData ss = SessionData.GetAppSession(Session);
            model.UserTao = ss.User.UserName;
            model.UserUpdate = ss.User.UserName;
            model.TrangThai = 1;
            bool bResult = pro.TaoUser(model, MaAccount);

            if (!bResult)
            {

                ModelState.AddModelError(string.Empty, ErrorMsg.MSG_NotSuccess_TaoAccount);
                string strMessage = this.RenderPartialViewToString("Error", ModelState);
                var obj = new
                {
                    result = true,
                    Data = strMessage,
                };
                return Json(obj);

            }
            return RedirectToAction("DanhSachUser", new { sField = "NgayUpdate", sSort = "DESC", MaAccount = MaAccount });
        }

        [HttpPost]
        public ActionResult TaoUserSameAccount(tblUser model, long MaAccount, long MaUser)
        {
            model.MaUser = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            model.NgayTao = DateTime.Now;
            model.NgayUpdate = DateTime.Now;
            SessionData ss = SessionData.GetAppSession(Session);
            model.UserTao = ss.User.UserName;
            model.UserUpdate = ss.User.UserName;
            model.TrangThai = 1;
            bool bResult = pro.TaoUser(model, MaAccount);

            if (!bResult)
            {

                ModelState.AddModelError(string.Empty, ErrorMsg.MSG_NotSuccess_TaoAccount);
                string strMessage = this.RenderPartialViewToString("Error", ModelState);
                var obj = new
                {
                    result = true,
                    Data = strMessage,
                };
                return Json(obj);

            }
            return RedirectToAction("DanhSachUserSameAccount", new { sField = "NgayUpdate", sSort = "DESC", MaUser = MaUser });
        }

        public ActionResult EditUser(long id, string sField, string sSort, int page, int pagesize, long MaAccount)
        {

            tblUserOver model = new tblUserOver();
            tblUser objUser = pro.getOneUser(id);
            model.MaUser = objUser.MaUser;
            model.UserName = objUser.UserName;
            model.Email = objUser.Email;
            model.GhiChu = objUser.GhiChu;
            model.FullName = objUser.FullName;
            model.DienThoai = objUser.DienThoai;
            model.DiaChi = objUser.DiaChi;
            model.Password = objUser.Password;
            model.NgayTao = objUser.NgayTao;
            model.NgayUpdate = objUser.NgayUpdate;
            model.UserTao = objUser.UserTao;
            model.UserUpdate = objUser.UserUpdate;
            model.TrangThai = objUser.TrangThai;

            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.MaAccount = MaAccount;
            return View(model);
        }

        public ActionResult EditUserSameAccount(long id, string sField, string sSort, int page, int pagesize, long MaAccount)
        {

            tblUserOver model = new tblUserOver();
            tblUser objUser = pro.getOneUser(id);
            model.MaUser = objUser.MaUser;
            model.UserName = objUser.UserName;
            model.Email = objUser.Email;
            model.GhiChu = objUser.GhiChu;
            model.FullName = objUser.FullName;
            model.DienThoai = objUser.DienThoai;
            model.DiaChi = objUser.DiaChi;
            model.Password = objUser.Password;
            model.NgayTao = objUser.NgayTao;
            model.NgayUpdate = objUser.NgayUpdate;
            model.UserTao = objUser.UserTao;
            model.UserUpdate = objUser.UserUpdate;
            model.TrangThai = objUser.TrangThai;

            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.MaAccount = MaAccount;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(tblUser model, string sField, string sSort, int page, int pagesize, long MaAccount)
        {
            if (ModelState.IsValid)
            {
                Process pro = new Process();
                SessionData ss = SessionData.GetAppSession(Session);
                model.UserUpdate = ss.User.UserName;
                model.NgayUpdate = DateTime.Now;
                bool bCheck = pro.UpdateUser(model);
                ViewBag.sField = sField;
                ViewBag.sSort = sSort;
                ViewBag.page = page;
                ViewBag.pagesize = pagesize;
                ViewBag.MaAccount = MaAccount;
                if (!bCheck)
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật user không thành công.");
                    return PartialView("EditUser", model);
                }
                return RedirectToAction("DanhSachUser", new { sField = "NgayUpdate", sSort = "DESC", MaAccount = MaAccount });
            }
            return PartialView("EditUser", model);
        }

        [HttpPost]
        public ActionResult EditUserSameAccount(tblUser model, string sField, string sSort, int page, int pagesize, long MaAccount, long MaUser)
        {
            if (ModelState.IsValid)
            {
                Process pro = new Process();
                SessionData ss = SessionData.GetAppSession(Session);
                model.UserUpdate = ss.User.UserName;
                model.NgayUpdate = DateTime.Now;
                bool bCheck = pro.UpdateUser(model);
                ViewBag.sField = sField;
                ViewBag.sSort = sSort;
                ViewBag.page = page;
                ViewBag.pagesize = pagesize;
                ViewBag.MaAccount = MaAccount;
                if (!bCheck)
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật user không thành công.");
                    return PartialView("EditUserSameAccount", model);
                }
                return RedirectToAction("DanhSachUserSameAccount", new { sField = "NgayUpdate", sSort = "DESC", MaUser = MaUser });
            }
            return PartialView("EditUserSameAccount", model);
        }

        public ActionResult ActiveUser(long MaAccount, long MaUser, int Status, string sTenUser, string sField, string sSort, int page, int pagesize)
        {
            bool bCheck = pro.ActiveUser(MaUser, MaAccount, Status);
            return RedirectToAction("DanhSachUser", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, MaAccount = MaAccount, sTenUser = sTenUser });
        }

        public ActionResult ActiveUserSameAccount(long MaAccount, long MaUser, int Status, string sTenUser, string sField, string sSort, int page, int pagesize)
        {
            bool bCheck = pro.ActiveUser(MaUser, MaAccount, Status);
            return RedirectToAction("DanhSachUserSameAccount", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, MaUser = MaUser, sTenUser = sTenUser });
        }

        public ActionResult ActiveUserSameAccountSearch(long MaAccount, long MaUser, int Status, string sTenUser, string sField, string sSort, int page, int pagesize)
        {
            bool bCheck = pro.ActiveUser(MaUser, MaAccount, Status);
            return RedirectToAction("DanhSachUserSameAccountSearch", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, MaUser = MaUser, sTenUser = sTenUser });
        }
        public ActionResult XoaUserSameAccount(FormCollection collection, long MaAccount, long MaUser)
        {

            if (collection != null)
            {

                string sId = collection["check_id"];
                if (sId == null)
                {
                    return RedirectToAction("DanhSachUserSameAccount", new { MaUser = MaUser });


                }
                string[] arrId = sId.Split(',');

                bool bCheck = pro.XoaUser(arrId, MaAccount);
                if (!bCheck)
                {

                }
            }
            return RedirectToAction("DanhSachUserSameAccount", new { MaUser = MaUser });
        }
    }
}