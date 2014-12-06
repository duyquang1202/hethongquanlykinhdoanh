using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using QLCongTacVien.Models;
using QLCongTacVien.Infrastructure.Extension;
using QLCongTacVien.Infrastructure;
using System.Web.Security;
using MvcPaging;
namespace QLCongTacVien.Controllers
{
    public class AccountController : BaseController
    {
        string strCountLogin = "CountLogin";
        [NotCheckLogin]
        [HttpGet]
        public ActionResult Login(int? Id)
        {
            SessionData ss = SessionData.GetAppSession(Session);
            if (ss != null && ss.User != null)
            {
                if (ss.LoginBackUrl == null)
                {
                    ss.LoginBackUrl = "~/PhongBan";
                }
                RedirectResult ret = this.Redirect(ss.LoginBackUrl);
                ss.LoginBackUrl = null;
                return ret;
            }
            if (Id == 1)
            {
                ViewBag.ShowError = true;
                ModelState.AddModelError(string.Empty, "Xin vui lòng đăng nhập để sử dụng chức năng này.");
            }
            return View();

        }

        [NotCheckLogin]
        [HttpPost]
        public ActionResult LogIn(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                Process pro = new Process();
                CheckLogin objCheckLogin = pro.CheckLogin(model.UserName, model.Password);
                if (!objCheckLogin.bCheckLogin)
                {
                    ModelState.AddModelError(string.Empty, "UserName hoặc mật khẩu không đúng");
                    ViewBag.ShowError = true;
                    return PartialView("Error");
                }

                SessionData ss = SessionData.GetAppSession(Session);
                UserSession user = new UserSession();
                ss.User = user;

                user.UserId = objCheckLogin.MaUser;
                user.UserName = objCheckLogin.UserName;
                user.UserFullName = objCheckLogin.FullName;
                if (ss.LoginBackUrl == null)
                {
                    ss.LoginBackUrl = Url.Action("Index", "PhongBan");
                }
                return JavaScript("top.location.href='" + ss.LoginBackUrl + "';");
                // RedirectResult ret = this.Redirect(ss.LoginBackUrl);

            }
            ModelState.AddModelError(string.Empty, "UserName hoặc mật khẩu để trống");
            ViewBag.ShowError = true;
            return PartialView("Error");
        }

        [NotCheckLogin]
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToLogin();

        }

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachAccount(long MaPhongBan, string sField, string sSort, int? page, int? pagesize, string sTenAccount, string LoaiAccount, long? AccountParent)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = sField != null ? sField : "TenAccount";
            sSort = sSort != null ? sSort : "ASC";

            SessionData ss = SessionData.GetAppSession(Session);
            tblPhongBan objPhongBan = pro.getDanhSachAccount(MaPhongBan, AccountParent, sTenAccount, LoaiAccount, sField, sSort, ss.User.UserId);
            AccountModel model = new AccountModel();

            model.ListAccount = objPhongBan.tblAccounts.ToList().ToPagedList(currentPageIndex, currentPageSize);
            model.MaPhongBan = objPhongBan.MaPhongBan;
            model.TenPhongBan = objPhongBan.TenPhongBan;
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            ViewBag.LoaiAccount = LoaiAccount;
            model.sTenAccount = sTenAccount;
            ViewBag.AccountParent = AccountParent;

            return PartialView("DanhSachAccount", model);
        }

        public ActionResult DanhSachAccountSearch(long MaPhongBan, string sTenAccount, string LoaiAccount, string sField, string sSort, int? page, int? pagesize, long? AccountParent)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = sField != null ? sField : "TenAccount";
            sSort = sSort != null ? sSort : "ASC";

            SessionData ss = SessionData.GetAppSession(Session);
            tblPhongBan objPhongBan = pro.getDanhSachAccount(MaPhongBan, AccountParent, sTenAccount, LoaiAccount, sField, sSort, ss.User.UserId);
            AccountModel model = new AccountModel();

            model.ListAccount = objPhongBan.tblAccounts.ToList().ToPagedList(currentPageIndex, currentPageSize);
            model.MaPhongBan = objPhongBan.MaPhongBan;
            model.TenPhongBan = objPhongBan.TenPhongBan;
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            model.sTenAccount = sTenAccount;
            ViewBag.LoaiAccount = LoaiAccount;
            ViewBag.AccountParent = AccountParent;
            return PartialView("DanhSachAccountSearch", model);
        }


        [HttpGet]
        public ActionResult TaoAccount(long MaPhongBan, long? AccountParent, string LoaiAccount, string TenPhongBan, string sField, string sSort, int page, int pagesize)
        {
            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.MaPhongBan = MaPhongBan;
            ViewBag.TenPhongBan = TenPhongBan;
            ViewBag.LoaiAccount = LoaiAccount;
            ViewBag.AccountParent = AccountParent;
            tblAccountOver model = new tblAccountOver();
            SessionData ss = SessionData.GetAppSession(Session);
            var user = pro.getOneUser(ss.User.UserId);

            model.LoaiAccount = user.tblAccounts.First().LoaiAccount;
            model.ListAccountManager = pro.getListAccountManager(MaPhongBan);
            return View(model);
        }

        [HttpPost]
        public ActionResult TaoAccount(tblAccount model, long MaPhongBan, string LoaiAccount)
        {


            model.MaAccount = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            model.NgayTao = DateTime.Now;
            model.NgayUpdate = DateTime.Now;
            SessionData ss = SessionData.GetAppSession(Session);
            model.UserTao = ss.User.UserName;
            model.UserUpdate = ss.User.UserName;
            model.TrangThai = 1;
            if (LoaiAccount == null)
            {
                if (model.LoaiAccount == "QL")
                {
                    model.AccountManager = (long)ss.User.UserId;
                }
                else
                {
                    model.AccountManager = model.AccountManager.HasValue ? model.AccountManager.Value : 0;

                }
            }
            else
            {
                model.AccountManager = model.AccountManager.HasValue ? model.AccountManager.Value : 0;
            }
            bool bResult = pro.TaoAccount(model, MaPhongBan);

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
            return RedirectToAction("DanhSachAccount", new { sField = "NgayUpdate", sSort = "DESC", MaPhongBan = MaPhongBan });
        }

        public ActionResult EditAccount(long id, string sField, string sSort, int page, int pagesize, long MaPhongBan, string LoaiAccount)
        {

            Process pro = new Process();
            tblAccountOver model = new tblAccountOver();
            tblAccount objAccount = pro.getOneAccount(id);
            model.MaAccount = objAccount.MaAccount;
            model.TenAccount = objAccount.TenAccount;
            model.AccountManager = objAccount.AccountManager;
            model.GhiChu = objAccount.GhiChu;
            model.LoaiAccount = objAccount.LoaiAccount;
            model.NgayTao = objAccount.NgayTao;
            model.NgayUpdate = objAccount.NgayUpdate;
            model.UserTao = objAccount.UserTao;
            model.UserUpdate = objAccount.UserUpdate;
            model.TrangThai = objAccount.TrangThai;

            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.MaPhongBan = MaPhongBan;
            ViewBag.LoaiAccount = LoaiAccount;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditAccount(tblAccount model, long MaPhongBan, string LoaiAccount)
        {
            if (ModelState.IsValid)
            {
                Process pro = new Process();
                SessionData ss = SessionData.GetAppSession(Session);
                model.UserUpdate = ss.User.UserName;
                model.NgayUpdate = DateTime.Now;
                bool bCheck = pro.UpdateAccount(model);

                if (!bCheck)
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật account không thành công.");
                    return PartialView("EditAccount", model);
                }
                return RedirectToAction("DanhSachAccount", new { sField = "NgayUpdate", sSort = "DESC", MaPhongBan = MaPhongBan, LoaiAccount = LoaiAccount });
            }
            return PartialView("EditAccount", model);
        }


        public ActionResult XoaAccount(FormCollection collection, long MaPhongBan, string LoaiAccount)
        {

            if (collection != null)
            {

                string sId = collection["check_id"];
                if (sId == null)
                {
                    return RedirectToAction("DanhSachAccount", new { MaPhongBan = MaPhongBan, LoaiAccount = LoaiAccount });

                }
                string[] arrId = sId.Split(',');
                Process pro = new Process();
                bool bCheck = pro.XoaAccount(arrId, MaPhongBan);
                if (!bCheck)
                {

                }
            }
            return RedirectToAction("DanhSachAccount", new { MaPhongBan = MaPhongBan, LoaiAccount = LoaiAccount });
        }

        public ActionResult ActiveAccount(long MaPhongBan, long MaAccount, string LoaiAccount, int Status, string sTenAccount, string sField, string sSort, int page, int pagesize)
        {
            Process pro = new Process();
            bool bCheck = pro.ActiveAccount(MaAccount, Status);
            return RedirectToAction("DanhSachAccount", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, MaPhongBan = MaPhongBan, sTenAccount = sTenAccount, LoaiAccount = LoaiAccount });
        }

        public ActionResult ActiveAccountSearch(long MaPhongBan, long MaAccount, string LoaiAccount, int Status, string sTenAccount, string sField, string sSort, int page, int pagesize)
        {
            Process pro = new Process();
            bool bCheck = pro.ActiveAccount(MaAccount, Status);
            return RedirectToAction("DanhSachAccountSearch", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, MaPhongBan = MaPhongBan, sTenAccount = sTenAccount, LoaiAccount = LoaiAccount });
        }

        [HttpPost]
        public JsonResult doesTenAccountExist(string TenAccount, long MaAccount = 0)
        {
            tblAccount account = null;
            if (MaAccount != 0)
            {
                var accountinfo = pro.getAccount(MaAccount);
                if (accountinfo != null)
                {
                    if (accountinfo.TenAccount != TenAccount)
                    {
                        account = pro.getAccount(TenAccount);

                    }

                }
            }
            else
            {
                account = pro.getAccount(MaAccount);
            }


            return Json(account == null);
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}