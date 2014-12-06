using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLCongTacVien.Infrastructure.Extension
{
    public class CheckPermissionAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public bool check;
        public CheckPermissionAttribute()
        {
            check = true;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            BaseController controller = filterContext.Controller as BaseController;
            if (controller == null)
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            // Check Login
            SessionData ss = SessionData.GetAppSession(filterContext.HttpContext.Session);
            /////
            AppMenu.UpdateMenuSelection(filterContext, ss);
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (ss != null)
            {
                if (ss.User == null)
                {
                    object[] objCheckLogin = filterContext.ActionDescriptor.GetCustomAttributes(typeof(NotCheckLoginAttribute), true);
                    // if required to check login
                    if (objCheckLogin.Length < 1)
                    {
                        // time out web
                        filterContext.Result = new RedirectToRouteResult(
                                            new RouteValueDictionary { 
                                                {"Controller", "Account"},
                                                {"Action","Login"},
                                                {"Id","1"}
                                            });
                        ss.Menu = new AppMenu();
                        ss.MenuId = new MenuType();
                        ss.LoginBackUrl = filterContext.HttpContext.Request.RawUrl;
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            if (filterContext.HttpContext.Request.Files["file"] != null)
                            {
                                var objreturn = new
                                {
                                    hasErr = 2,
                                };
                                JsonResult result1 = new JsonResult();
                                result1.ContentType = "text/plain";
                                result1.Data = objreturn;
                            }
                            else
                            {
                                filterContext.Result = new JavaScriptResult() { Script = "top.location.reload()" };
                            }
                        }
                        base.OnActionExecuting(filterContext);
                        return;
                    }
                }
            }
            // Get menu Id
            MenuType menuId = AppMenu.GetMenuType(controllerName, actionName);
            if (ss != null && ss.MenuId != menuId)
            {
                ss.MenuId = menuId;
                //ss.Menu = AppMenu.GetMenu(menuId, (ss.User == null ? null : ss.User.Functions));
                ss.Menu = AppMenu.GetMenu(menuId, null);
            }
            base.OnActionExecuting(filterContext);
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            BaseController controller = filterContext.Controller as BaseController;
            if (controller == null)
            {
                base.OnActionExecuted(filterContext);
                return;
            }
            //if (filterContext.ActionDescriptor.ActionName == "Search")
            if (controller.HasSessionError)
            {

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{ { "Controller", "Account"},
                                              { "Action", "Login" },
                                              { "Id", "2" },
                                            });
                if (controller.TempData.ContainsKey("ErrMsg"))
                {
                    controller.TempData.Remove("ErrMsg");
                }
                controller.TempData.Add("ErrMsg", ErrorMsg.GetErrorMsg(controller.ErrorCode));

                //Check Login
                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                SessionData ss = SessionData.GetAppSession(filterContext.HttpContext.Session);
                if (ss != null)
                {
                    ss.LoginBackUrl = filterContext.HttpContext.Request.RawUrl;
                    //ss.LoginBackAction = actionName;
                    //ss.LoginBackController = controllerName;
                    //ss.LoginBackParams = new RouteValueDictionary(filterContext.RouteData.Values);
                }

                ss.Menu = new AppMenu();
                ss.MenuId = new MenuType();
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JavaScriptResult() { Script = "top.location.reload()" };
                }
            }
            base.OnActionExecuted(filterContext);
            //req

        }

        public void OnException(ExceptionContext filterContext)
        {
            //if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            //{
            //    filterContext.Result = new RedirectResult("/SpecialErrorPage.html");
            //    filterContext.ExceptionHandled = true;
            //}
        }

    }
}