using QLCongTacVien.Infrastructure;
using QLCongTacVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
namespace QLCongTacVien.Controllers
{
    public class PhongBanController : BaseController
    {


        //
        // GET: /PhongBan/
        [HttpGet]
        public ActionResult Index()
        {
            int currentPageIndex = 0;
            int currentPageSize = 10;
            ListPhongBanModel model = new ListPhongBanModel();
            string sField = "TenPhongBan";
            string sSort = "ASC";
            LstPhongBanModel lst = new LstPhongBanModel();
            SessionData ss = SessionData.GetAppSession(Session);
            lst.ListPhongBan = pro.GetDanhSachPhongBan(sField, sSort, null, ss.User.UserId).ToPagedList(currentPageIndex, currentPageSize);
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            ViewBag.MaUser = ss.User.UserId;
            var user = pro.getOneUser(ss.User.UserId);
            ViewBag.LoaiAccount = user.tblAccounts.First().LoaiAccount;
            // model.ListPhongBan=lstPhongBan.
            return View(lst);
            //return View();
        }




        public ActionResult DanhSachPhongBan(string sField, string sSort, int? page, int? pagesize, string sTenPhongBan)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = (sField != null) ? sField : "TenPhongBan";
            sSort = (sSort != null) ? sSort : "ASC";
            LstPhongBanModel lst = new LstPhongBanModel();
            SessionData ss = SessionData.GetAppSession(Session);
            lst.ListPhongBan = pro.GetDanhSachPhongBan(sField, sSort, sTenPhongBan, ss.User.UserId).ToPagedList(currentPageIndex, currentPageSize);
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            ViewBag.MaUser = ss.User.UserId;
            var user = pro.getOneUser(ss.User.UserId);
            ViewBag.LoaiAccount = user.tblAccounts.First().LoaiAccount;
            lst.sTenPhongBan = sTenPhongBan;
            return View(lst);
            //ListPhongBanModel model = new ListPhongBanModel();
            //model.ListPhongBan = pro.GetDanhSachPhongBan();
            //return View(model);
        }

        public ActionResult DanhSachPhongBanSearch(string sField, string sSort, int? page, int? pagesize, string sTenPhongBan)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int currentPageSize = pagesize.HasValue ? pagesize.Value : 10;
            sField = (sField != null) ? sField : "TenPhongBan";
            sSort = (sSort != null) ? sSort : "ASC";
            LstPhongBanModel lst = new LstPhongBanModel();
            SessionData ss = SessionData.GetAppSession(Session);
            lst.ListPhongBan = pro.GetDanhSachPhongBan(sField, sSort, sTenPhongBan, ss.User.UserId).ToPagedList(currentPageIndex, currentPageSize);
            ViewBag.sField = sField;
            ViewBag.sIcon = sSort.ToLower();
            ViewBag.sSort = sSort;
            ViewBag.MaUser = ss.User.UserId;
            var user = pro.getOneUser(ss.User.UserId);
            ViewBag.LoaiAccount = user.tblAccounts.First().LoaiAccount;
            lst.sTenPhongBan = sTenPhongBan;
            return PartialView("DanhSachPhongBanSearch", lst);
            //ListPhongBanModel model = new ListPhongBanModel();
            //model.ListPhongBan = pro.GetDanhSachPhongBan();
            //return View(model);
        }

        [HttpGet]
        public ActionResult TaoPhongBan(string sField, string sSort, int page, int pagesize, string sTenPhongBan)
        {
            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.sTenPhongBan = sTenPhongBan;

            return PartialView("TaoPhongBan");
        }

        public ActionResult EditPhongBan(long id, string sField, string sSort, int page, int pagesize, string sTenPhongBan)
        {
            PhongBanModel model = new PhongBanModel();
            Process pro = new Process();
            model = pro.getOnePhongBan(id);
            ViewBag.sField = sField;
            ViewBag.sSort = sSort;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.sTenPhongBan = sTenPhongBan;
            return PartialView("CapNhatPhongBan", model);
        }

        public ActionResult XoaPhongBan(FormCollection collection)
        {
            if (collection != null)
            {
                string sId = collection["check_id"];
                if (sId == null)
                {
                    return RedirectToAction("DanhSachPhongBan");

                }
                string[] arrId = sId.Split(',');
                Process pro = new Process();
                bool bCheck = pro.XoaPhongBan(arrId);
                if (!bCheck)
                {

                }
            }
            return RedirectToAction("DanhSachPhongBan");
        }

        [HttpPost]
        public ActionResult EditPhongBan(PhongBanModel model)
        {
            if (ModelState.IsValid)
            {
                Process pro = new Process();
                SessionData ss = SessionData.GetAppSession(Session);
                model.UserUpdate = ss.User.UserName;
                bool bCheck = pro.UpdatePhongBan(model);

                if (!bCheck)
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật phòng ban không thành công.");
                    return PartialView("CapNhatPhongBan", model);
                }
                return RedirectToAction("DanhSachPhongBan", new { sField = "NgayUpdate", sSort = "DESC" });
            }
            return PartialView("CapNhatPhongBan", model);

        }

        public ActionResult ActivePhongBan(long id, int status, string sField, string sSort, int page, int pagesize, string sTenPhongBan)
        {
            Process pro = new Process();
            bool bCheck = pro.ActivePhongBan(id, status);
            return RedirectToAction("DanhSachPhongBan", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, sTenPhongBan = sTenPhongBan });
        }

        public ActionResult ActivePhongBanSearch(long id, int status, string sField, string sSort, int page, int pagesize, string sTenPhongBan)
        {
            Process pro = new Process();
            bool bCheck = pro.ActivePhongBan(id, status);
            return RedirectToAction("DanhSachPhongBanSearch", new { sField = sField, sSort = sSort, page = page, pagesize = pagesize, sTenPhongBan = sTenPhongBan });
        }

        [HttpPost]
        public ActionResult TaoPhongBan(PhongBanModel model)
        {


            model.MaPhongBan = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            model.NgayTao = DateTime.Now;
            model.NgayUpdate = DateTime.Now;
            SessionData ss = SessionData.GetAppSession(Session);
            model.UserTao = ss.User.UserName;
            model.UserUpdate = ss.User.UserName;
            model.TrangThai = 1;
            bool bResult = pro.TaoPhongBan(model);


            if (!bResult)
            {

                ModelState.AddModelError(string.Empty, ErrorMsg.MSG_NotSuccess_TaoPhongBan);


                string strMessage = this.RenderPartialViewToString("Error", ModelState);
                var obj = new
                {
                    result = true,
                    Data = strMessage,
                };
                return Json(obj);

            }
            return RedirectToAction("DanhSachPhongBan", new { sField = "NgayUpdate", sSort = "DESC" });


        }



    }
}