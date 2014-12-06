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
    public class NhomController : BaseController
    {
        //
        // GET: /Nhom/
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
	}
}