using QLCongTacVien.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCongTacVien
{
    public class BaseController : Controller
    {
        bool _hasSessionError = false;
        public bool HasSessionError
        {
            get
            {
                return _hasSessionError;
            }
        }
        int _errorCode = 0;
        public int ErrorCode
        {
            get
            {
                return _errorCode;
            }
        }
        protected Process pro;
        public BaseController()
        {
            pro = new Process();
        }

        public ActionResult RedirectToLogin()
        {
            return RedirectToAction("LogIn", "Account");
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}